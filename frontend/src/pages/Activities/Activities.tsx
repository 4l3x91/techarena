import ActivityCard from "./components/ActivityCard"
import activities from "./data/activities"

const Activities = () => {
  return (
    <div className="container container-fluid my-2">
    <h2>Activities</h2>
    {activities.map((activity) => (
        <ActivityCard activity={activity} key={activity.id} />
    ))}
    </div>
  )
}

export default Activities