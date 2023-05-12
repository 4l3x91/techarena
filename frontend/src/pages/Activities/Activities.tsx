import { useQuery } from "react-query";
import { useUser } from "../../contexts/UserContext";
import ActivityCard from "./components/ActivityCard";

const Activities = () => {
  const {currentUser} = useUser();
  console.log(currentUser)
  const { data: interests } = useQuery(["interests"], async () => {
    return await fetch(`http://localhost:5296/Interest/GetMyInterests?userId=${currentUser?.id}`).then((res) => res.json());
  });
  console.log(interests)

  if(!interests) return null;
  return (
    <div className="container container-fluid my-2">
    <h2>Activities</h2>
    {interests.length === 0 ? <p>You have no activities yet.</p>: <>
    {interests.map((activity: any) => (
      <ActivityCard activity={activity} key={activity.id} />
      ))}
      </>}
    </div>
  )
}

export default Activities