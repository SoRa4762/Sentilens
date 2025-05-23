import type { IUserData } from "@/interfaces/auth";
import { Navigate } from "react-router-dom";

const ProtectedRoute = ({ children }: { children: React.ReactNode }) => {
  const getUserToken = localStorage.getItem("userData");

  if (typeof getUserToken !== "string")
    return <Navigate to="/signin" replace />;

  const parsedUserToken: IUserData = JSON.parse(getUserToken);
  if (parsedUserToken.token) return <>{children}</>;
};

export default ProtectedRoute;
