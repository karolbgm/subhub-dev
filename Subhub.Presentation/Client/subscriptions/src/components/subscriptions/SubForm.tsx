import { ChangeEvent, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { SubDto } from "../../models/subDto";
import apiConnector from "../../api/apiConnector";

export default function SubForm() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [subscription, setSubscription] = useState<SubDto>({
    id: undefined,
    name: "",
    category: "",
    type: "",
    cost: 0,
    paymentDate: undefined,
    period: 0,
    isActive: true,
    createDate: undefined,
  });

  useEffect(() => {
    if (id) {
      apiConnector
        .getSubscriptionById(id)
        .then((subscription) => setSubscription(subscription!));
    }
  }, [id]);

  function handleSubmit() {
    if (window.event) {
      window.event.preventDefault();
    }
    if (!subscription.id) {
      apiConnector.createSubscription(subscription).then(() => navigate("/"));
    } else {
      apiConnector.editSubscription(subscription).then(() => navigate("/"));
    }
  }

  function handleChange(event: ChangeEvent<HTMLInputElement>) {
    const { name, value } = event.target;

    setSubscription({ ...subscription, [name]: value });
  }

  return (
    <>
      <div className="row">
        <h3 className="my-5">
          {id ? "Edit Subscription" : "New Subscription"}
        </h3>

        <div className="" style={{ maxWidth: "400px" }}>
          <form onSubmit={handleSubmit}>
            <div className="mb-3">
              <label className="form-label" htmlFor="name">
                Subscription Name
              </label>
              <input
                className="form-control"
                type="text"
                name="name"
                id="name"
                value={subscription.name}
                onChange={handleChange}
              />
            </div>
            <div className="mb-3">
              <label className="form-label" htmlFor="cost">
                Cost
              </label>
              <input
                className="form-control"
                type="number"
                name="cost"
                id="cost"
                value={subscription.cost}
                onChange={handleChange}
              />
            </div>
            <div className="mb-3">
              <label className="form-label" htmlFor="period">
                Period (months)
              </label>
              <input
                className="form-control"
                type="number"
                name="period"
                id="period"
                value={subscription.period}
                onChange={handleChange}
              />
            </div>
            <div className="mb-3">
              <label className="form-label" htmlFor="paymentDate">
                Payment Date (YY-MM-DD)
              </label>
              <input
                className="form-control"
                type="string"
                name="paymentDate"
                id="paymentDate"
                value={subscription.paymentDate?.slice(0, 10)}
                onChange={handleChange}
              />
            </div>
            <div className="mb-3">
              <label className="form-label" htmlFor="category">
                Category
              </label>
              <input
                className="form-control"
                type="string"
                name="category"
                id="category"
                value={subscription.category}
                onChange={handleChange}
              />
            </div>
            <div className="mb-3">
              <label className="form-label" htmlFor="type">
                Type
              </label>
              <input
                className="form-control"
                type="string"
                name="type"
                id="type"
                value={subscription.type}
                onChange={handleChange}
              />
            </div>
            <div className="mb-3">
              <button type="submit" className="btn btn-primary">
                Submit
              </button>
              <Link to="/" className="btn btn-primary ms-2">
                Cancel
              </Link>
            </div>
          </form>
        </div>
      </div>
    </>
  );
}
