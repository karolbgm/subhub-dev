import { useEffect, useState } from "react";
import { SubDto } from "../../models/subDto";
import apiConnector from "../../api/apiConnector";
import { Button } from "react-bootstrap";
import TableItem from "./TableItem";
import { Link } from "react-router-dom";
import PieChart from "./PieChart";

export default function SubhubTable() {
  // State declarations using useState hook
  const [subscriptions, setSubscriptions] = useState<SubDto[]>([]);
  const [totalCost, setTotalCost] = useState<number>(0);
  const [pieChartData, setPieChartData] = useState<{
    labels: string[];
    datasets: { data: number[]; backgroundColor: string[] }[];
  } | null>(null);

    // useEffect hook for fetching data and calculating total cost and expense breakdown
  useEffect(() => {
    const fetchData = async () => {
      const fetchedSubscriptions = await apiConnector.getSubscriptions();
      setSubscriptions(fetchedSubscriptions);

      // Filter monthly subscriptions and calculate total cost
      const monthlySubscriptions = fetchedSubscriptions.filter(
        (subscription) => subscription.period === 1
      );
      const total = monthlySubscriptions.reduce(
        (acc, subscription) => acc + subscription.cost,
        0
      );
      setTotalCost(total);

      // Extract categories and their corresponding costs
      const categoryMap = new Map<string, number>();
      fetchedSubscriptions.forEach((subscription) => {
        const existingCost = categoryMap.get(subscription.category) || 0;
        categoryMap.set(
          subscription.category,
          existingCost + subscription.cost
        );
      });

      // Prepare data for the pie chart
      const labels = Array.from(categoryMap.keys());
      const colors = generateColors(labels); // Generate colors based on labels
      const data = {
        labels: labels,
        datasets: [
          {
            data: labels.map((label) => categoryMap.get(label) || 0),
            backgroundColor: colors,
          },
        ],
      };

      setPieChartData(data);
    };

    fetchData();
  }, []);

  // Function to generate colors based on labels
  const generateColors = (labels: string[]) => {
    const colorMap: { [label: string]: string } = {
      Entertainment: "blue",
      Utilities: "green",
      "Health & Fitness": "orange",
      "Shopping & Lifestyle": "purple",
      Business: "red",
      Other: "gray",
      // Add more labels and colors as needed
    };

    return labels.map((label) => colorMap[label] || "black");
  };

  return (
    <>
      <div className="container ms-5">
        <div className="row">
          <div className="col-md-8">
            <Link to="createSubscription">
              <Button variant="dark" className="mt-5">
                <i className="fa-solid fa-plus me-2"></i>New Subscription
              </Button>
            </Link>
            <div className="album py-5">
              <div className="container">
                <div className="row row-cols-1 row-cols-sm-2 row-cols-md-1 row-cols-lg-2 row-cols-xl-3  g-3">
                  {subscriptions.length !== 0 &&
                    subscriptions.map((subscription, index) => (
                      <TableItem key={index} subscription={subscription} />
                    ))}
                </div>
              </div>
            </div>
          </div>
          <div className="col-md-4" style={{ marginTop: "125px" }}>
            <div className="card">
              <div className="card-body">
                <h5 className="card-title">Recurring Expenses</h5>
                <hr
                  className="align-center"
                  style={{ maxWidth: "400px", marginBottom: "1rem" }}
                />
                <p className="card-text" style={{ textAlign: "center" }}>
                  <div>
                    <h3 style={{ display: "inline" }}>
                      <strong>${totalCost.toFixed(2)}</strong>
                    </h3>{" "}
                    USD Monthly
                  </div>
                </p>
              </div>
            </div>
            <div className="card">
              <div className="card-body">
                <h5 className="card-title">Expense Breakdown</h5>
                <hr
                  className="align-center"
                  style={{ maxWidth: "400px", marginBottom: "1rem" }}
                />

                {pieChartData && <PieChart data={pieChartData} />}
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
