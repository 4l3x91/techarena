import { useQuery } from "react-query";
import { useUser } from "../../contexts/UserContext";

const Profile = () => {
  const { currentUser } = useUser();

  const { data: interests } = useQuery(["interests"], async () => {
    return await fetch(`http://localhost:5296/Interest/GetMyInterests?userId=${currentUser?.id}`).then((res) => res.json());
  });

  if (!interests) return null;

  return (
    <div className="container container-fluid my-2">
      <h2>Profile</h2>
      <div className="d-flex align-items-center mb-2">
        <img src={currentUser?.profilePictureURL} className="rounded-circle w-25" />
        <div className="text-center d-flex flex-fill gap-4 justify-content-center">
          <div>
            <div className="fs-5">{currentUser?.age}</div>
            <div className="fs-7">Age</div>
          </div>
          <div>
            <div className="fs-5">{interests.length}</div>
            <div className="fs-7">Interests</div>
          </div>
          <div>
            <div className="fs-5">17</div>
            <div className="fs-7">Events</div>
          </div>
        </div>
      </div>
      <div>{currentUser?.name}</div>
      <div className="fs-5">About me</div>
      <div>
        Lorem ipsum dolor sit, amet consectetur adipisicing elit. Neque labore ipsum saepe, facere placeat aliquam beatae explicabo qui dolor enim
        modi aperiam harum animi numquam reiciendis in! Maxime, necessitatibus assumenda!
      </div>
    </div>
  );
};

export default Profile;
