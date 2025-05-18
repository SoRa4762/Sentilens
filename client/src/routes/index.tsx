import { lazy, Suspense } from "react";
import App from "../App";
import Loader from "@/components/common/Loader.tsx";
import DashboardLayout from "@/components/layout/DashboardLayout.tsx";

const Home = lazy(() => import("../pages/Home.tsx"));
const About = lazy(() => import("../pages/About.tsx"));
const NotFound = lazy(() => import("../pages/NotFound.tsx"));
const Dashboard = lazy(() => import("../pages/Dashboard.tsx"));

// Routes configuration
const index = [
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "/",
        element: (
          <Suspense fallback={<Loader />}>
            <Home />
          </Suspense>
        ),
      },
      {
        path: "/about",
        element: (
          <Suspense fallback={<Loader />}>
            <About />
          </Suspense>
        ),
      },
      {
        path: "/dashboard",
        element: (
          <Suspense fallback={<Loader />}>
            <DashboardLayout />
          </Suspense>
        ),
        children: [
          {
            index: true,
            element: (
              <Suspense fallback={<Loader />}>
                <Dashboard />
              </Suspense>
            ),
          },
        ],
      },
      {
        path: "*",
        element: (
          <Suspense>
            <NotFound />
          </Suspense>
        ),
      },
    ],
  },
];

export default index;
