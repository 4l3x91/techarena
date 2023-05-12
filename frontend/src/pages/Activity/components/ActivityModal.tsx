import { BsFillBarChartFill } from "react-icons/bs";
import { VscLocation } from "react-icons/vsc";
interface Props {
  modal: boolean;
  user: any;
  index: number;
}

const ActivityModal = ({ modal, user, index }: Props) => {
  return (
    <div className="modal modal-fullscreen fade" id={`exampleModal-${index}`} aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
        <div className="modal-content  bg-dark">
          <div className="modal-header">
            <h5 className="modal-title" id="exampleModalLabel">
              Activity details
            </h5>
            <button type="button" className="btn-close-white btn-close" data-bs-dismiss={modal} aria-label="Close" />
          </div>
          <div className="modal-body">
            <div className="d-flex align-items-center gap-2">
              <img src={user.profilePictureURL} className="rounded-circle" alt="" />
              <div>
                <div className="mb-2">
                  {user.username}, {user.age} - {user.gender}
                </div>
                <div className="fs-7">{user.about}</div>
              </div>
            </div>
            <div className="mt-4 d-flex flex-column gap-2">
              <div className="">Details</div>
              <div className="d-flex gap-2 align-items-center">
                <BsFillBarChartFill size={20} /> <p className="mb-0 fs-7">{user.level}</p>
              </div>

              <div className="d-flex gap-2 align-items-center">
                <VscLocation size={20} /> <p className="mb-0 fs-7">{user.location ? user.location.locatioName : "Anywhere"}</p>
              </div>
            </div>
          </div>
          <div className="modal-footer">
            <button type="button" className="btn btn-secondary" data-bs-dismiss={modal}>
              Close
            </button>
            <button type="button" className="btn btn-primary">
              Match!
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ActivityModal;
