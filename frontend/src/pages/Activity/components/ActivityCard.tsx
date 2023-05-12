import { useState } from "react";
import { BsFillBarChartFill } from "react-icons/bs";
import { VscLocation } from "react-icons/vsc";
import ActivityModal from "./ActivityModal";
interface Props {
  user: any;
  index: number;
}

const ActivityCard = ({ user, index }: Props) => {
  const [modal, setModal] = useState(false);
  if (!user) return null;
  return (
    <div onClick={() => setModal((prev) => !prev)}
      className="card bg-dark text-white p-0"
      data-bs-toggle={"modal"}
      data-bs-target={`#exampleModal-${index}`} // Use userId here to make each modalId unique
    >
      <img
        src={user.profilePictureURL}
        height="auto"
        className="card-img-top"
        alt="User profile picture"
      />
      <div className="card-body p-2">
        <p className="m-0 fs-7 fw-bold">
          {user.username}
        </p>
        <div className="d-flex align-items-center gap-2">
          <BsFillBarChartFill />
          <p className="m-0 fs-7">{user.level}</p>
        </div>
        <div className="d-flex align-items-center gap-2">
          <VscLocation />
          <p className="m-0 fs-7">{user.location}</p>
        </div>
      </div>
      <ActivityModal index={index} user={user} modal={modal} />
    </div>
  );
};

export default ActivityCard;
