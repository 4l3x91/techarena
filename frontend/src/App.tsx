import { useEffect } from "react";
import { Route, Routes } from "react-router-dom";
import "./App.scss";
import Layout from "./Layout";
import { useUser } from "./contexts/UserContext";
import Activities from "./pages/Activities/Activities";
import Activity from "./pages/Activity/Activity";
import Event from "./pages/Event/Event";
import Events from "./pages/Events/Events";
import Login from "./pages/Login/Login";
import Profile from "./pages/Profile/Profile";

function App() {
  const { currentUser, token, setCurrentUser } = useUser();

  const getAuth = async (token: string) => {
    if (token) {
      const response = await fetch("http://localhost:5296/authenticate/isAuthenticated", {
        method: "GET",
        headers: { "Content-Type": "application/json", Authorization: `Bearer ${token}` },
      });
      if (response.status === 200) {
        const deserializedResponse = await response.json();
        setCurrentUser(deserializedResponse);
      }
    }
  };

  useEffect(() => {
    if (token != "") {
      getAuth(token);
    }
  }, [token]);

  return (
    <Routes>
      {currentUser?.token !== "" ? (
        <Route path="/" element={<Layout />}>
          <Route path="/" element={<Activities />} />
          <Route path="activities/:id" element={<Activity />} />
          <Route path="events/" element={<Events />} />
          <Route path="events/:id" element={<Event />} />
          <Route path="profile" element={<Profile />} />
        </Route>
      ) : (
        <Route index element={<Login />} />
      )}
    </Routes>
  );
}

export default App;
