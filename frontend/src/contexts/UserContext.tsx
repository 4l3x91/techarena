import { createContext, ReactNode, useContext, useEffect, useState } from "react";
import { useLocalStorage } from "../hooks/useLocalStorage";

interface User {
  id: number;
  name: string;
  password: string;
  gender: string;
  token: string;
  profilePictureURL: string;
  birthdate: Date;
  age: number;
  about: string;
  authUserId: string;
}
export interface SignInDto extends Pick<User, "name" | "password"> {
  name: string;
  password: string;
}

interface UserContext {
  currentUser: User | undefined;
  // loginUser: (user: User) => void;
  token: string;
  setToken: (token: string) => void;
  setCurrentUser: React.Dispatch<React.SetStateAction<User>>;
}

const UserContext = createContext<UserContext>({
  currentUser: {} as User,
  // loginUser: () => console.warn("No provider found."),
  token: "",
  setToken: () => console.warn("No provider found."),
  setCurrentUser: () => console.log("no provider found"),
});

interface Props {
  children: ReactNode;
}

const UserProvider = ({ children }: Props) => {
  // const [currentUser, setCurrentUser] = useLocalStorage<User | undefined>("user", undefined);
  const [currentUser, setCurrentUser] = useState<User>({
    name: "",
    token: "",
    password: "",
    gender: "",
    profilePictureURL: "",
    birthdate: new Date(),
    age: 0,
    about: "",
    authUserId: "",
  } as User);
  const [token, setToken] = useLocalStorage<string>("token", "");

  // const loginUser = (user: User) => {
  //   if (user) {
  //     setCurrentUser(user);
  //   }
  // };

  useEffect(() => {
    console.log(currentUser);
  }, [currentUser]);

  return <UserContext.Provider value={{ currentUser, token, setToken, setCurrentUser }}>{children}</UserContext.Provider>;
};

export const useUser = () => useContext(UserContext);

export default UserProvider;
