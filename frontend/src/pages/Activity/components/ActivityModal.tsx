
interface Props {
    modal: boolean;
    user: any;
    index: number;
}

const ActivityModal = ({modal, user, index}: Props) => {

  return (
    <div
    className="modal modal-fullscreen fade"
    id={`exampleModal-${index}`}
    aria-labelledby="exampleModalLabel"
    aria-hidden="true"
  >
    <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
      <div className="modal-content  bg-dark">
        <div className="modal-header">
          <h5 className="modal-title" id="exampleModalLabel">
            Activity details
          </h5>
          <button
            type="button"
            className="btn-close-white btn-close"
            data-bs-dismiss={modal}
            aria-label="Close"
          ></button>
        </div>
        <div className="modal-body">
            <div className="d-flex align-items-center gap-2">
            <img src={user.picture.large} className="rounded-circle" alt="" />
            <div>
            <div className="mb-2">{user.name.first} {user.name.last}, {user.dob.age} - {user.gender}</div>
            <div className="fs-7">Jag är en glad tjej som söker en liten träningskompis, uppskattar dubbelskjortor!</div>
            </div>
            </div>
        </div>
        <div className="modal-footer">
          <button
            type="button"
            className="btn btn-secondary"
            data-bs-dismiss={modal}
          >
            Close
          </button>
          <button type="button" className="btn btn-primary">
            Match!
          </button>
        </div>
      </div>
    </div>
  </div>

  )
}

export default ActivityModal