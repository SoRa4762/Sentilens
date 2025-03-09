import React from "react";

const NotFoundPage: React.FC = () => {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-slate-50 px-4">
      <div className="max-w-md w-full">
        {/* Logo */}
        <div className="flex items-center justify-center">
          <div className="flex items-center justify-center w-10 h-10 bg-indigo-600 rounded-md">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 24 24"
              fill="none"
              stroke="white"
              strokeWidth="2"
              strokeLinecap="round"
              strokeLinejoin="round"
              className="w-6 h-6"
            >
              <path d="M4 6h16M4 12h16M4 18h12"></path>
              <circle cx="9" cy="9" r="1"></circle>
              <circle cx="15" cy="15" r="1"></circle>
            </svg>
          </div>
          <span className="ml-2 text-xl font-bold text-indigo-600">
            SentiLens
          </span>
        </div>

        {/* Error content */}
        <div className="text-center">
          <h1 className="text-9xl font-bold text-slate-200">404</h1>
          <h2 className="mt-4 text-2xl font-medium text-slate-800">
            Page not found
          </h2>
          <p className="mt-2 text-slate-600">
            The page you're looking for doesn't exist or has been moved.
          </p>

          <div className="mt-8">
            <a
              href="/"
              className="inline-flex items-center justify-center px-6 py-3 border border-transparent text-base font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 transition-all duration-200"
            >
              Return home
            </a>
          </div>
        </div>

        {/* Subtle decorative element */}
        <div className="mt-16 flex justify-center">
          <div className="h-px w-16 bg-slate-200"></div>
        </div>
      </div>
    </div>
  );
};

export default NotFoundPage;
