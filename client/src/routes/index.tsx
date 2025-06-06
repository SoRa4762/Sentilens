import { lazy, Suspense } from "react";
import App from "../App";
import Loader from "@/components/common/Loader.tsx";
import DashboardLayout from "@/components/layout/DashboardLayout.tsx";
import AuthLayout from "@/pages/Auth/auth-layout.tsx";
import SigninForm from "@/pages/Auth/signin-form.tsx";
import SignupForm from "@/pages/Auth/signup-form.tsx";
import ForgotPasswordForm from "@/pages/Auth/forgot-password-form.tsx";
import ResetPasswordForm from "@/pages/Auth/reset-password-form.tsx";

const Home = lazy(() => import("../pages/home.tsx"));
const About = lazy(() => import("../pages/about.tsx"));
const NotFound = lazy(() => import("../pages/not-found.tsx"));
const Dashboard = lazy(() => import("../pages/dashboard.tsx"));

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
        path: "/signin",
        element: (
          <Suspense fallback={<Loader />}>
            <AuthLayout
              heading="Welcome back"
              subHeading="Sign in to your account to continue"
              footerText="Don't have an account?"
              footerLinkText="Create an account"
              footerLinkHref="/signup"
            >
              <SigninForm />
              {/* children does not have to be passed through props */}
            </AuthLayout>
          </Suspense>
        ),
      },
      {
        path: "/signup",
        element: (
          <Suspense fallback={<Loader />}>
            <AuthLayout
              heading="Create an account"
              subHeading="Create an account to get started"
              footerText="Already have an account?"
              footerLinkText="Sign in"
              footerLinkHref="/signin"
            >
              <SignupForm />
            </AuthLayout>
          </Suspense>
        ),
      },
      {
        path: "/forgot-password",
        element: (
          <AuthLayout
            heading="Forgot Password"
            subHeading="Enter your email to reset your password"
            footerText="Remember your password?"
            footerLinkText="Sign In"
            footerLinkHref="/signin"
          >
            <ForgotPasswordForm />
          </AuthLayout>
        ),
      },
      {
        path: "/reset-password",
        element: (
          <AuthLayout
            heading="Reset Password"
            subHeading="Enter your OTP and new password to reset your password"
            footerText="Remember your password?"
            footerLinkText="Sign In"
            footerLinkHref="/signin"
            // children={}
          >
            <ResetPasswordForm />
          </AuthLayout>
        ),
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
