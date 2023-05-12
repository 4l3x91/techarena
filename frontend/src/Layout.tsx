import { Outlet } from "react-router-dom"
import BottomTabs from "./shared/components/BottomTabs/BottomTabs"


const Layout = () => {
  return (
   <>
   <main className="">
    <Outlet />
   </main>
    <BottomTabs />
   </>
  )
}

export default Layout