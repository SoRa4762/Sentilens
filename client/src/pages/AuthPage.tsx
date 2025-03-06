import { useState } from "react";
import { FaGoogle, FaFacebook, FaApple } from "react-icons/fa";

const AuthPage = () => {
  const [isLogin, setIsLogin] = useState(true);
  const [formData, setFormData] = useState({
    fullName: "",
    email: "",
    password: "",
    confirmPassword: "",
    agreeToTerms: false,
  });

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData({
      ...formData,
      [name]: type === "checkbox" ? checked : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Here you would implement your authentication logic
    console.log("Form submitted:", formData);
  };

  const toggleAuthMode = () => {
    setIsLogin(!isLogin);
  };

  return (
    <div className="flex flex-col min-h-screen bg-gradient-to-br from-blue-50 to-indigo-50">
      <div className="flex flex-col items-center justify-center flex-grow px-4 py-8">
        {/* App Logo */}
        <div className="mb-8 text-center">
          <div className="flex items-center justify-center w-16 h-16 mx-auto mb-2 bg-indigo-600 rounded-full shadow-lg">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 24 24"
              fill="none"
              stroke="white"
              strokeWidth="2"
              strokeLinecap="round"
              strokeLinejoin="round"
              className="w-8 h-8"
            >
              <path d="M4 6h16M4 12h16M4 18h12"></path>
              <path d="M8 3v3M12 3v3M16 3v3"></path>
              <circle cx="9" cy="9" r="1"></circle>
              <circle cx="15" cy="15" r="1"></circle>
            </svg>
          </div>
          <h1 className="text-2xl font-bold text-gray-800">Sentilens</h1>
          <p className="text-gray-600">
            Filter your news with sentiment analysis
          </p>
        </div>

        {/* Auth Container */}
        <div className="w-full max-w-md">
          {/* Login/Signup Toggle */}
          <div className="flex p-1 mb-6 overflow-hidden bg-gray-100 rounded-lg">
            <button
              className={`flex-1 py-2 text-sm font-medium rounded-md transition-all ${
                isLogin
                  ? "bg-white text-indigo-600 shadow"
                  : "text-gray-600 hover:text-gray-800"
              }`}
              onClick={() => setIsLogin(true)}
            >
              Login
            </button>
            <button
              className={`flex-1 py-2 text-sm font-medium rounded-md transition-all ${
                !isLogin
                  ? "bg-white text-indigo-600 shadow"
                  : "text-gray-600 hover:text-gray-800"
              }`}
              onClick={() => setIsLogin(false)}
            >
              Sign Up
            </button>
          </div>

          {/* Form Container */}
          <div className="p-6 bg-white rounded-lg shadow-lg">
            <form onSubmit={handleSubmit}>
              {!isLogin && (
                <div className="mb-4">
                  <label
                    htmlFor="fullName"
                    className="block mb-2 text-sm font-medium text-gray-700"
                  >
                    Full Name
                  </label>
                  <input
                    id="fullName"
                    name="fullName"
                    type="text"
                    required={!isLogin}
                    value={formData.fullName}
                    onChange={handleChange}
                    className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-transparent"
                    placeholder="Your full name"
                  />
                </div>
              )}

              <div className="mb-4">
                <label
                  htmlFor="email"
                  className="block mb-2 text-sm font-medium text-gray-700"
                >
                  Email Address
                </label>
                <input
                  id="email"
                  name="email"
                  type="email"
                  required
                  value={formData.email}
                  onChange={handleChange}
                  className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-transparent"
                  placeholder="your.email@example.com"
                />
              </div>

              <div className="mb-4">
                <label
                  htmlFor="password"
                  className="block mb-2 text-sm font-medium text-gray-700"
                >
                  Password
                </label>
                <input
                  id="password"
                  name="password"
                  type="password"
                  required
                  value={formData.password}
                  onChange={handleChange}
                  className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-transparent"
                  placeholder="••••••••"
                />
              </div>

              {!isLogin && (
                <div className="mb-4">
                  <label
                    htmlFor="confirmPassword"
                    className="block mb-2 text-sm font-medium text-gray-700"
                  >
                    Confirm Password
                  </label>
                  <input
                    id="confirmPassword"
                    name="confirmPassword"
                    type="password"
                    required={!isLogin}
                    value={formData.confirmPassword}
                    onChange={handleChange}
                    className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-transparent"
                    placeholder="••••••••"
                  />
                </div>
              )}

              {isLogin && (
                <div className="flex justify-end mb-4">
                  <button
                    type="button"
                    className="text-sm text-indigo-600 hover:text-indigo-800"
                  >
                    Forgot Password?
                  </button>
                </div>
              )}

              {!isLogin && (
                <div className="mb-4">
                  <div className="flex items-center">
                    <input
                      id="agreeToTerms"
                      name="agreeToTerms"
                      type="checkbox"
                      required={!isLogin}
                      checked={formData.agreeToTerms}
                      onChange={handleChange}
                      className="w-4 h-4 text-indigo-600 border-gray-300 rounded focus:ring-indigo-500"
                    />
                    <label
                      htmlFor="agreeToTerms"
                      className="block ml-2 text-sm text-gray-700"
                    >
                      I agree to the{" "}
                      <a
                        href="#"
                        className="text-indigo-600 hover:text-indigo-800"
                      >
                        Terms & Conditions
                      </a>
                    </label>
                  </div>
                </div>
              )}

              <button
                type="submit"
                className="w-full px-4 py-3 mt-2 font-medium text-white transition-colors bg-indigo-600 rounded-md hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
              >
                {isLogin ? "Login" : "Sign Up"}
              </button>

              <div className="flex items-center my-4">
                <div className="flex-grow h-px bg-gray-300"></div>
                <span className="px-3 text-sm text-gray-500">OR</span>
                <div className="flex-grow h-px bg-gray-300"></div>
              </div>

              <div className="flex justify-center space-x-4">
                <button
                  type="button"
                  className="flex items-center justify-center w-12 h-12 text-red-600 transition-colors bg-white border border-gray-300 rounded-full hover:bg-gray-50"
                >
                  <FaGoogle className="w-5 h-5" />
                </button>
                <button
                  type="button"
                  className="flex items-center justify-center w-12 h-12 text-blue-600 transition-colors bg-white border border-gray-300 rounded-full hover:bg-gray-50"
                >
                  <FaFacebook className="w-5 h-5" />
                </button>
                <button
                  type="button"
                  className="flex items-center justify-center w-12 h-12 text-gray-800 transition-colors bg-white border border-gray-300 rounded-full hover:bg-gray-50"
                >
                  <FaApple className="w-5 h-5" />
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>

      {/* Footer */}
      <footer className="py-4 mt-8 text-center bg-white shadow-inner">
        <div className="container mx-auto">
          <div className="flex flex-wrap justify-center space-x-6 text-sm text-gray-600">
            <a href="#" className="hover:text-indigo-600">
              About Us
            </a>
            <a href="#" className="hover:text-indigo-600">
              Contact
            </a>
            <a href="#" className="hover:text-indigo-600">
              Privacy
            </a>
            <a href="#" className="hover:text-indigo-600">
              Terms
            </a>
          </div>
        </div>
      </footer>
    </div>
  );
};

export default AuthPage;
