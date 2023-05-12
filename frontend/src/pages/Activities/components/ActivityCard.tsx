import { NavLink } from "react-router-dom";
interface Props {
    activity: any;
  }
const ActivityCard = ({activity}: Props) => {
  return (
    <NavLink className="text-decoration-none text-white" to={`activities/${activity.id}`}>
    <div className="card bg-dark mb-2" key={activity.id}>
        <img src={activity.imageUrl} className="card-img-top" alt="..." />
        <div className="card-body">
          <h5 className="m-0">{activity.name}</h5>
        </div>
      </div>
    </NavLink>
  )
}

export default ActivityCard