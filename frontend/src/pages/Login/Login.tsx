import { useState } from "react";
import { useUser } from "../../contexts/UserContext";

const Login = () => {
  const { setToken } = useUser();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (event: React.ChangeEvent<EventTarget>) => {
    event.preventDefault();
    await fetch("http://localhost:5296/Authenticate/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ username: username, password: password }),
    }).then((res) =>
      res.json().then((data) => setToken(!data.token ? "" : data.token))
    );
  };

  return (
    <div className="container container-fluid h-100 d-flex flex-column">
      <form
        className="d-flex justify-content-center flex-column flex-fill"
      >
        <img
          src="https://avatars.githubusercontent.com/u/90207950?v=4"
          className="w-50 mx-auto mb-4"
          alt=""
        />
        <div className="mb-3">
          <label className="form-label">Username</label>
          <input
            type="email"
            className="form-control"
            id="exampleInputEmail1"
            aria-describedby="emailHelp"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
          <div id="emailHelp" className="form-text">
            We'll never share your credentials with anyone else.
          </div>
        </div>
        <div className="mb-3">
          <label className="form-label">Password</label>
          <input
            type="password"
            className="form-control"
            id="exampleInputPassword1"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button type="submit" className="btn btn-primary" onClick={handleSubmit}>
          Log in
        </button>
      </form>
    </div>
  );
};

export default Login;
