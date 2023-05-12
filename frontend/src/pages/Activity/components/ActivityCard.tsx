import { useState } from "react";
import { BsFillBarChartFill } from "react-icons/bs";
import { VscLocation } from "react-icons/vsc";
import { useQuery } from "react-query";
import ActivityModal from "./ActivityModal";
interface Props {
  activity: any;
  index: number;
}

const ActivityCard = ({ activity, index }: Props) => {
  const [modal, setModal] = useState(false);
  const { data: users } = useQuery(["user", index], () => {
    return fetch("https://randomuser.me/api/").then((res) => res.json());
  });
  if (!users) return null;
  return (
    <div onClick={() => setModal((prev) => !prev)}
      className="card bg-dark text-white p-0"
      data-bs-toggle={"modal"}
      data-bs-target={`#exampleModal-${index}`} // Use userId here to make each modalId unique
    >
      <img
        src={users.results[0].picture.large}
        height="auto"
        className="card-img-top"
        alt="User profile picture"
      />
      <div className="card-body p-2">
        <p className="m-0 fs-7 fw-bold">
          {users.results[0].name.first} {users.results[0].name.last},{" "}
          {users.results[0].dob.age}
        </p>
        <div className="d-flex align-items-center gap-2">
          <BsFillBarChartFill />
          <p className="m-0 fs-7">Novice</p>
        </div>
        <div className="d-flex align-items-center gap-2">
          <VscLocation />
          <p className="m-0 fs-7">Anywhere</p>
        </div>
      </div>
      <ActivityModal user={users.results[0]} modal={modal} index={index} />
    </div>
  );
};

export default ActivityCard;
