import ProtectedRoute from "@/routes/ProtectedRoute";
import React from "react";

type Props = {};

const About = (props: Props) => {
  return (
    <ProtectedRoute>
      <div>About</div>
    </ProtectedRoute>
  );
};

export default About;
