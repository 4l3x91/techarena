const Profile = () => {
  return (
    <div className="container container-fluid my-2">
      <h2>Profile</h2>
      <div className="d-flex align-items-center mb-2">
        <img
          src="https://randomuser.me/api/portraits/men/46.jpg"
          className="rounded-circle w-25"
        />
        <div className="text-center d-flex flex-fill gap-4 justify-content-center">
          <div>
            <div className="fs-5">35</div>
            <div className="fs-7">Age</div>
          </div>
          <div>
            <div className="fs-5">5</div>
            <div className="fs-7">Interests</div>
          </div>
          <div>
            <div className="fs-5">17</div>
            <div className="fs-7">Events</div>
          </div>
        </div>
      </div>
      <div>Jimmy</div>
      <div className="fs-5">About me</div>
      <div>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Neque labore ipsum saepe, facere placeat aliquam beatae explicabo qui dolor enim modi aperiam harum animi numquam reiciendis in! Maxime, necessitatibus assumenda!</div>
    </div>
  );
};

export default Profile;
