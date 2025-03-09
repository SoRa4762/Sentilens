import React, { useState, useEffect } from "react";
import {
  FaFacebook,
  FaTwitter,
  FaLinkedin,
  FaChartLine,
  FaFilter,
  FaNewspaper,
} from "react-icons/fa";

// Testimonial type definition
interface Testimonial {
  id: number;
  quote: string;
  author: string;
  position: string;
}

const LandingPage: React.FC = () => {
  const [activeTestimonial, setActiveTestimonial] = useState<number>(0);
  const [isMenuOpen, setIsMenuOpen] = useState<boolean>(false);

  // Sample testimonials
  const testimonials: Testimonial[] = [
    {
      id: 1,
      quote:
        "This tool has completely transformed how I consume news. The sentiment analysis helps me understand the emotional tone behind articles instantly.",
      author: "Sarah Johnson",
      position: "Marketing Director",
    },
    {
      id: 2,
      quote:
        "As a financial analyst, getting unbiased news is crucial. This platform helps me filter out emotionally charged content and focus on facts.",
      author: "Michael Chen",
      position: "Investment Analyst",
    },
    {
      id: 3,
      quote:
        "The customizable filters are incredible. I can now avoid doom-scrolling and focus on balanced reporting that doesn't affect my mental health.",
      author: "Priya Sharma",
      position: "Clinical Psychologist",
    },
  ];

  // Auto-rotate testimonials
  useEffect(() => {
    const interval = setInterval(() => {
      setActiveTestimonial((prev) => (prev + 1) % testimonials.length);
    }, 5000);
    return () => clearInterval(interval);
  }, [testimonials.length]);

  // Toggle mobile menu
  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  return (
    <div className="flex flex-col min-h-screen font-sans text-gray-800">
      {/* Header */}
      <header className="sticky top-0 z-50 bg-white shadow-sm">
        <div className="container mx-auto px-4 py-4">
          <div className="flex items-center justify-between">
            {/* Logo */}
            <div className="flex items-center">
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

            {/* Desktop Navigation */}
            <nav className="hidden md:flex">
              <ul className="flex space-x-8">
                <li>
                  <a
                    href="#home"
                    className="text-gray-800 hover:text-indigo-600 transition-colors"
                  >
                    Home
                  </a>
                </li>
                <li>
                  <a
                    href="#about"
                    className="text-gray-800 hover:text-indigo-600 transition-colors"
                  >
                    About Us
                  </a>
                </li>
                <li>
                  <a
                    href="#features"
                    className="text-gray-800 hover:text-indigo-600 transition-colors"
                  >
                    Features
                  </a>
                </li>
                <li>
                  <a
                    href="#pricing"
                    className="text-gray-800 hover:text-indigo-600 transition-colors"
                  >
                    Pricing
                  </a>
                </li>
                <li>
                  <a
                    href="#contact"
                    className="text-gray-800 hover:text-indigo-600 transition-colors"
                  >
                    Contact
                  </a>
                </li>
              </ul>
            </nav>

            {/* Mobile Menu Button */}
            <button
              className="md:hidden p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500"
              onClick={toggleMenu}
              aria-label="Toggle menu"
            >
              <svg
                className="w-6 h-6"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg"
              >
                {isMenuOpen ? (
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M6 18L18 6M6 6l12 12"
                  />
                ) : (
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M4 6h16M4 12h16M4 18h16"
                  />
                )}
              </svg>
            </button>
          </div>

          {/* Mobile Navigation */}
          {isMenuOpen && (
            <nav className="mt-4 md:hidden">
              <ul className="flex flex-col space-y-3 pb-4">
                <li>
                  <a
                    href="#home"
                    className="block text-gray-800 hover:text-indigo-600 transition-colors"
                    onClick={toggleMenu}
                  >
                    Home
                  </a>
                </li>
                <li>
                  <a
                    href="#about"
                    className="block text-gray-800 hover:text-indigo-600 transition-colors"
                    onClick={toggleMenu}
                  >
                    About Us
                  </a>
                </li>
                <li>
                  <a
                    href="#features"
                    className="block text-gray-800 hover:text-indigo-600 transition-colors"
                    onClick={toggleMenu}
                  >
                    Features
                  </a>
                </li>
                <li>
                  <a
                    href="#pricing"
                    className="block text-gray-800 hover:text-indigo-600 transition-colors"
                    onClick={toggleMenu}
                  >
                    Pricing
                  </a>
                </li>
                <li>
                  <a
                    href="#contact"
                    className="block text-gray-800 hover:text-indigo-600 transition-colors"
                    onClick={toggleMenu}
                  >
                    Contact
                  </a>
                </li>
              </ul>
            </nav>
          )}
        </div>
      </header>

      {/* Hero Section */}
      <section
        id="home"
        className="relative py-20 md:py-32 bg-gradient-to-br from-indigo-50 to-blue-50"
      >
        <div className="absolute inset-0 bg-opacity-50 pointer-events-none">
          <svg
            className="absolute right-0 transform translate-x-1/2"
            width="404"
            height="404"
            fill="none"
            viewBox="0 0 404 404"
            aria-hidden="true"
          >
            <defs>
              <pattern
                id="pattern-circles"
                x="0"
                y="0"
                width="20"
                height="20"
                patternUnits="userSpaceOnUse"
              >
                <circle
                  cx="10"
                  cy="10"
                  r="3"
                  className="text-indigo-200"
                  fill="currentColor"
                />
              </pattern>
            </defs>
            <rect width="404" height="404" fill="url(#pattern-circles)" />
          </svg>
        </div>
        <div className="container mx-auto px-4 z-10 relative">
          <div className="max-w-3xl mx-auto text-center">
            <h1 className="text-4xl md:text-5xl lg:text-6xl font-bold leading-tight mb-6 text-gray-900">
              Filter News Based on{" "}
              <span className="text-indigo-600">Emotional Tone</span>
            </h1>
            <p className="text-lg md:text-xl text-gray-600 mb-10">
              Our AI-powered sentiment analysis helps you understand the
              emotional context behind news articles, letting you filter content
              based on tone and bias.
            </p>
            <div className="flex flex-col sm:flex-row justify-center space-y-4 sm:space-y-0 sm:space-x-4">
              <a
                href="/auth"
                className="bg-indigo-600 hover:bg-indigo-700 text-white font-medium py-3 px-8 rounded-md transition-all transform hover:-translate-y-px shadow-md hover:shadow-lg"
              >
                Get Started
              </a>
              <a
                href="#about"
                className="bg-white hover:bg-gray-50 text-indigo-600 border border-indigo-200 font-medium py-3 px-8 rounded-md transition-all transform hover:-translate-y-px shadow-sm hover:shadow"
              >
                Learn More
              </a>
            </div>
          </div>
        </div>
      </section>

      {/* Features Section */}
      <section id="features" className="py-16 md:py-24 bg-white">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h2 className="text-3xl md:text-4xl font-bold mb-4 text-gray-900">
              Powerful Features
            </h2>
            <p className="text-gray-600 max-w-2xl mx-auto">
              Discover how our sentiment analysis tools can transform your news
              consumption experience.
            </p>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
            {/* Feature 1 */}
            <div className="bg-gray-50 p-6 md:p-8 rounded-lg text-center hover:shadow-md transition-shadow">
              <div className="inline-flex items-center justify-center w-16 h-16 bg-indigo-100 text-indigo-600 rounded-full mb-6">
                <FaChartLine className="w-8 h-8" />
              </div>
              <h3 className="text-xl font-semibold mb-3">Sentiment Analysis</h3>
              <p className="text-gray-600">
                Our AI analyzes the emotional tone of articles, categorizing
                them as positive, negative, or neutral to help you understand
                the underlying sentiment.
              </p>
            </div>

            {/* Feature 2 */}
            <div className="bg-gray-50 p-6 md:p-8 rounded-lg text-center hover:shadow-md transition-shadow">
              <div className="inline-flex items-center justify-center w-16 h-16 bg-indigo-100 text-indigo-600 rounded-full mb-6">
                <FaFilter className="w-8 h-8" />
              </div>
              <h3 className="text-xl font-semibold mb-3">
                Customizable Filters
              </h3>
              <p className="text-gray-600">
                Create personalized news feeds by filtering content based on
                sentiment, sources, topics, and more. Take control of your news
                consumption.
              </p>
            </div>

            {/* Feature 3 */}
            <div className="bg-gray-50 p-6 md:p-8 rounded-lg text-center hover:shadow-md transition-shadow">
              <div className="inline-flex items-center justify-center w-16 h-16 bg-indigo-100 text-indigo-600 rounded-full mb-6">
                <FaNewspaper className="w-8 h-8" />
              </div>
              <h3 className="text-xl font-semibold mb-3">Balanced Reporting</h3>
              <p className="text-gray-600">
                Get a balanced view of current events by seeing multiple
                perspectives and understanding the emotional context behind each
                article.
              </p>
            </div>
          </div>
        </div>
      </section>

      {/* Testimonials Section */}
      <section className="py-16 md:py-24 bg-gray-50">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h2 className="text-3xl md:text-4xl font-bold mb-4 text-gray-900">
              What Our Users Say
            </h2>
            <p className="text-gray-600 max-w-2xl mx-auto">
              Learn how SentiLens has changed the way people consume news.
            </p>
          </div>

          <div className="max-w-4xl mx-auto">
            <div className="bg-white rounded-lg shadow-md p-8 md:p-10">
              <div className="relative">
                <svg
                  className="absolute top-0 left-0 transform -translate-x-6 -translate-y-8 h-16 w-16 text-indigo-200 opacity-50"
                  fill="currentColor"
                  viewBox="0 0 32 32"
                  aria-hidden="true"
                >
                  <path d="M9.352 4C4.456 7.456 1 13.12 1 19.36c0 5.088 3.072 8.064 6.624 8.064 3.36 0 5.856-2.688 5.856-5.856 0-3.168-2.208-5.472-5.088-5.472-.576 0-1.344.096-1.536.192.48-3.264 3.552-7.104 6.624-9.024L9.352 4zm16.512 0c-4.8 3.456-8.256 9.12-8.256 15.36 0 5.088 3.072 8.064 6.624 8.064 3.264 0 5.856-2.688 5.856-5.856 0-3.168-2.304-5.472-5.184-5.472-.576 0-1.248.096-1.44.192.48-3.264 3.456-7.104 6.528-9.024L25.864 4z" />
                </svg>

                <div className="relative min-h-[180px] flex flex-col justify-between">
                  <p className="text-xl text-gray-600 mb-6">
                    {testimonials[activeTestimonial].quote}
                  </p>
                  <div>
                    <p className="font-medium text-gray-900">
                      {testimonials[activeTestimonial].author}
                    </p>
                    <p className="text-gray-500">
                      {testimonials[activeTestimonial].position}
                    </p>
                  </div>
                </div>
              </div>
            </div>

            {/* Testimonial Navigation Dots */}
            <div className="flex justify-center mt-8 space-x-2">
              {testimonials.map((_, index) => (
                <button
                  key={index}
                  onClick={() => setActiveTestimonial(index)}
                  className={`w-3 h-3 rounded-full transition-colors ${
                    index === activeTestimonial
                      ? "bg-indigo-600"
                      : "bg-gray-300 hover:bg-indigo-300"
                  }`}
                  aria-label={`View testimonial ${index + 1}`}
                />
              ))}
            </div>
          </div>
        </div>
      </section>

      {/* Call-to-Action Section */}
      <section className="py-16 md:py-24 bg-indigo-600 text-white">
        <div className="container mx-auto px-4 text-center">
          <h2 className="text-3xl md:text-4xl font-bold mb-6">
            Ready to Transform Your News Experience?
          </h2>
          <p className="text-indigo-100 max-w-2xl mx-auto mb-10 text-lg">
            Join thousands of users who are taking control of their news
            consumption with our sentiment analysis tools.
          </p>
          <a
            href="/auth"
            className="inline-block bg-white text-indigo-600 hover:bg-indigo-50 font-bold py-3 px-8 rounded-md shadow-md hover:shadow-lg transition-all transform hover:-translate-y-px"
          >
            Sign Up Now
          </a>
        </div>
      </section>

      {/* Footer */}
      <footer className="bg-gray-800 text-gray-200 py-12">
        <div className="container mx-auto px-4">
          <div className="flex flex-col md:flex-row justify-between items-center">
            <div className="flex items-center mb-6 md:mb-0">
              <div className="flex items-center justify-center w-10 h-10 bg-indigo-500 rounded-md">
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
              <span className="ml-2 text-xl font-bold text-white">
                SentiLens
              </span>
            </div>

            <div className="flex justify-center space-x-6 mb-6 md:mb-0">
              <a
                href="#"
                className="text-gray-400 hover:text-white transition-colors"
                aria-label="Facebook"
              >
                <FaFacebook className="w-6 h-6" />
              </a>
              <a
                href="#"
                className="text-gray-400 hover:text-white transition-colors"
                aria-label="Twitter"
              >
                <FaTwitter className="w-6 h-6" />
              </a>
              <a
                href="#"
                className="text-gray-400 hover:text-white transition-colors"
                aria-label="LinkedIn"
              >
                <FaLinkedin className="w-6 h-6" />
              </a>
            </div>

            <div className="flex justify-center space-x-6">
              <a
                href="#"
                className="text-gray-400 hover:text-white transition-colors"
              >
                Privacy Policy
              </a>
              <a
                href="#"
                className="text-gray-400 hover:text-white transition-colors"
              >
                Terms of Service
              </a>
            </div>
          </div>

          <div className="text-center mt-8 text-gray-400 text-sm">
            <p>
              &copy; {new Date().getFullYear()} SentiLens. All rights reserved.
            </p>
          </div>
        </div>
      </footer>
    </div>
  );
};

export default LandingPage;
