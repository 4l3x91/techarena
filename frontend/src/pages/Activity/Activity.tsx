import { BsChevronLeft } from "react-icons/bs";
import { useNavigate } from "react-router-dom";
import ActivityCard from "./components/ActivityCard";
import styles from "./style.module.scss";
const Activity = () => {
  const navigate = useNavigate();

  // Get the current activity from the backend
  return (
    <div className="container container-fluid my-2">
      <div className="align-items-center d-flex gap-2 mb-2">
      <BsChevronLeft size={24} onClick={() => navigate("/")} />
    <h2 className="mb-0">Current activity</h2>
      </div>
    <div className={styles.grid}>
    {Array.from({ length: 10 }).map((activity, idx) => (
      <ActivityCard key={idx} index={idx} activity={activity} />
    ))}
    </div>
    </div>
  )
}

export default Activity