import { AiOutlineCalendar } from "react-icons/ai";
import { BiTimeFive } from "react-icons/bi";
import { BsFillBarChartFill } from "react-icons/bs";
import { useQuery } from "react-query";
import { NavLink } from "react-router-dom";

interface Props {
  event: any;
  index: number;
}
const EventCard = ({event, index}: Props) => {
  const randomNumber = Math.floor(Math.random() * 5) + 1;
  const { data: users } = useQuery(["thumbnails", index], () => {
    return fetch("https://randomuser.me/api/").then((res) => res.json());
  });
  if (!users) return null;
  console.log(event)
  return (
    <NavLink className="text-decoration-none text-white" to={`${event.id}`}>
    <div className="card bg-dark mb-2" key={event.id}>
        <div className="card-body">
          <div className="d-flex gap-2 align-items-center">
          <h5 className="mb-0 me-auto">{event.title}</h5>
          <div className="d-flex gap-1">
          {Array.from({ length: randomNumber }).map((activity, idx) => (
            <img src={users.results[0].picture.thumbnail} className="rounded-circle" height="28" />
            ))}
          </div>
            </div>
          <div className="d-flex gap-2 align-items-center">
          <BsFillBarChartFill />
          <p className="mb-0">Novice</p>
          </div>
          <div className="d-flex gap-2 align-items-center">
          <BiTimeFive />
          <p className="mb-0">{event.time}</p>
          </div>
          <div className="d-flex gap-2 align-items-center">
          <AiOutlineCalendar />
          <p className="mb-0">{event.date}</p>
          </div>
        </div>
      </div>
    </NavLink>
  )
}

export default EventCard