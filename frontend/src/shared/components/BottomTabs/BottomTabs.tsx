import { AiOutlineCalendar, AiOutlineHome, AiOutlineUser } from "react-icons/ai";
import { NavLink } from "react-router-dom";
import styles from "./style.module.scss";
const BottomTabs = () => {
  return (
    <nav className={`${styles.nav} sticky-bottom bg-dark`}>
      <ul className="navbar-nav d-flex flex-row w-100">
        <li className={styles.nav_item}>
          <NavLink className={`${styles.navlink} nav-link`} aria-current="page" to="/"><AiOutlineHome size={22} /><p className="mb-0 fs-7">Activities</p></NavLink>
        </li>
        <li className={styles.nav_item}>
          <NavLink className={`${styles.navlink} nav-link`} aria-current="page" to="/events"><AiOutlineCalendar size={22} /><p className="mb-0 fs-7">Event</p></NavLink>
        </li>
        <li className={styles.nav_item}>
          <NavLink className={`${styles.navlink} nav-link`} aria-current="page" to="/profile"><AiOutlineUser size={22} /><p className="mb-0 fs-7">Profile</p></NavLink>
        </li>

      </ul>
</nav>
  )
}

export default BottomTabs