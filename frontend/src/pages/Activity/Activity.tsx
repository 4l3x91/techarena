import { BsChevronLeft } from "react-icons/bs";
import { useQuery } from "react-query";
import { useNavigate, useParams } from "react-router-dom";
import { useUser } from "../../contexts/UserContext";
import ActivityCard from "./components/ActivityCard";
import styles from "./style.module.scss";
const Activity = () => {
  const navigate = useNavigate();
  const id = useParams();
  const currentUser = useUser();

  // Get the current activity from the backend
  //  http://localhost:5296/UserActivity/GetAllUserInterestByInterestId?interestId=92ad0454-4088-442a-97ab-30003b59bdc6

  const { data: usersWithInterests } = useQuery(["userInterests", id.id], async () => {
    return await fetch(`http://localhost:5296/UserActivity/GetAllUserInterestByInterestId?interestId=${id.id}`).then((res) => res.json());
  });

  const { data: interests } = useQuery(["interests"], async () => {
    return await fetch("http://localhost:5296/Interest/GetAllInterests").then((res) => res.json());
  });

  const currentActivity = interests?.find((x) => x.id === id.id);

  if (!usersWithInterests || !interests) return null;
  return (
    <div className="container container-fluid my-2">
      <div className="align-items-center d-flex gap-2 mb-2">
        <BsChevronLeft size={24} onClick={() => navigate("/")} />
        <h2 className="mb-0">{currentActivity.name}</h2>
      </div>
      <div className={styles.grid}>
        {usersWithInterests
          .filter((x) => x.profilePictureURL !== currentUser.currentUser?.profilepictureurl)
          .map((user: any, index: number) => (
            <ActivityCard key={index} index={index} user={user} />
          ))}
      </div>
    </div>
  );
};

export default Activity;
