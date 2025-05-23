import ProtectedRoute from "@/routes/ProtectedRoute";
import React from "react";

type Props = {};

const Home = (props: Props) => {
  return (
    <ProtectedRoute>
      <div className="font-bold">Home</div>;
    </ProtectedRoute>
  );
};

export default Home;
