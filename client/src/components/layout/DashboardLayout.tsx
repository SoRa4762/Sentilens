import { Outlet } from "react-router-dom";
import ProtectedRoute from "../common/ProtectedRoute";

const DashboardLayout = () => (
  <ProtectedRoute>
    <div className="dashboard-layout">
      <div className="dashboard-nav">{/* Navigation */}</div>
      <Outlet />
    </div>
  </ProtectedRoute>
);

export default DashboardLayout;
