import EventCard from "./components/EventCard"
import events from "./data/events"

const Events = () => {
  return (
    <div className="container container-fluid my-2">
    <h2>Events</h2>
    {events.map((event, idx) => (
        <EventCard event={event} index={idx} key={event.id} />
    ))}
    </div>
  )
}

export default Events