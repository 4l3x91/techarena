import { createContext, ReactNode, useContext, useState } from "react";
import { useLocalStorage } from "../hooks/useLocalStorage";

interface User {
  id: number;
  username: string;
  password: string;
  gender: string;
  token: string;
}
export interface SignInDto extends Pick<User, "username" | "password"> {
  username: string;
  password: string;
}

interface UserContext {
  currentUser: User | undefined;
  loginUser: (user: User) => void;
  token: string;
  setToken: (token: string) => void;
  setCurrentUser: React.Dispatch<React.SetStateAction<User>>;
}

const UserContext = createContext<UserContext>({
  currentUser: {} as User,
  loginUser: () => console.warn("No provider found."),
  token: "",
  setToken: () => console.warn("No provider found."),
  setCurrentUser: () => console.log("no provider found"),
});

interface Props {
  children: ReactNode;
}

const UserProvider = ({ children }: Props) => {
  // const [currentUser, setCurrentUser] = useLocalStorage<User | undefined>("user", undefined);
  const [currentUser, setCurrentUser] = useState<User>({ username: "", token: "", password: "password" } as User);
  const [token, setToken] = useLocalStorage<string>("token", "");

  const loginUser = (user: User) => {
    if (user) {
      setCurrentUser(user);
    }
  };

  // useEffect(() => {
  //   if (!token) {
  //     localStorage.setItem("user", JSON.stringify({}));
  //   } else {
  //       // setCurrentUser(localStorage.getItem("user"));
  //   }
  // }, [token]);

  return <UserContext.Provider value={{ currentUser, loginUser, token, setToken, setCurrentUser }}>{children}</UserContext.Provider>;
};

export const useUser = () => useContext(UserContext);

export default UserProvider;
