import { SubDto } from "../../models/subDto";
import apiConnector from "../../api/apiConnector";
import { Link } from "react-router-dom";
interface Props {
  subscription: SubDto;
}

export default function TableItem({ subscription }: Props) {
  let background, icon;
  if (subscription.type === "Streaming") {
    background = "card l-bg-cherry";
    icon = "fas fa-play fa-xs";
  } else if (subscription.type === "Membership") {
    background = "card l-bg-green-dark";
    icon = "fas fa-ticket-alt fa-xs";
  } else if (subscription.type === "Service") {
    background = "card l-bg-blue-dark";
    icon = "fas fa-screwdriver-wrench fa-xs";
  } else if (subscription.type === "Product") {
    background = "card l-bg-orange-dark";
    icon = "fas fa-box fa-xs";
  } else if (subscription.type === "License") {
    background = "card l-bg-purple-dark";
    icon = "fas fa-file fa-xs";
  } else {
    background = "card l-bg-aqua";
    icon = "fas fa-globe fa-xs";
  }
  return (
    <>
      <div className="col">
        <div className={background}>
          <div className="card-statistic-3 p-2" style={{ maxHeight: "100px" }}>
            <div className="card-icon card-icon-large mt-1">
              <i className={icon}></i>
            </div>
            <div className="d-flex justify-content-end mt-2">
              <Link
                to={`editSubscription/${subscription.id}`}
                className="link-icon"
              >
                <i className="fa-solid fa-pencil fa-sm me-2"></i>{" "}
              </Link>{" "}
              <i
                className="fa-solid fa-trash fa-sm me-2"
                onClick={async () => {
                  await apiConnector.deleteSubscription(subscription.id!);
                  window.location.reload();
                }}
              ></i>
            </div>
            <div className="d-flex justify-content-between">
              <div className="py-0 mb-4 mx-2">
                <h5>{subscription.name}</h5>
                <h6>{subscription.type}</h6>
              </div>
              <div className="d-flex">
                <div className=" py-0 mx-5">
                  <h4 className="">${subscription.cost}</h4>
                  <small className="text-white">
                    / {subscription.period} mo
                  </small>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
