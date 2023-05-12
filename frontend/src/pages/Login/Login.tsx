import { useQuery } from "react-query";
import { useUser } from "../../contexts/UserContext";

const Login = () => {
  const {currentUser, loginUser, setToken} = useUser();
  const { data: login } = useQuery(["user"], () => {
    return fetch("http://localhost:5296/Authenticate/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({username: "test", password: "Asd123!"}),
    }).then((res) => res.json().then((data) => console.log(data)));
  });

  console.log(login);
  
  return (
    <div className="container container-fluid h-100 d-flex flex-column">
    <form className="d-flex justify-content-center flex-column flex-fill">
      <img src="https://avatars.githubusercontent.com/u/90207950?v=4" className="w-50 mx-auto mb-4" alt="" />
  <div className="mb-3">
    <label className="form-label">Email address</label>
    <input type="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" />
    <div id="emailHelp" className="form-text">We'll never share your email with anyone else.</div>
  </div>
  <div className="mb-3">
    <label className="form-label">Password</label>
    <input type="password" className="form-control" id="exampleInputPassword1" />
  </div>
  <div className="mb-3 form-check">
    <input type="checkbox" className="form-check-input" id="exampleCheck1" />
    <label className="form-check-label">Check me out</label>
  </div>
  <button type="submit" className="btn btn-primary">Log in</button>
</form>
    </div>
  )
}

export default Login