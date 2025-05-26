import React from "react";
import { SentilensLogo } from "@/components/sentilens-logo";
import { Link } from "react-router-dom";

interface IAuthLayoutProps {
  children: React.ReactNode;
  heading: string;
  subHeading: string;
  footerText: string;
  footerLinkText: string;
  footerLinkHref: string;
}

const AuthLayout = ({
  children,
  heading,
  subHeading,
  footerText,
  footerLinkText,
  footerLinkHref,
}: IAuthLayoutProps) => {
  return (
    <div className="h-screen w-full flex flex-col px-4 justify-between items-center">
      <header className="h-14 w-full">
        <Link to="/" className="h-full w-full flex items-center gap-2">
          <SentilensLogo className="h-8 w-8" />
          <span className="font-bold text-xl">Sentilens</span>
        </Link>
      </header>
      <main className="w-[90%] sm:w-[30rem] flex flex-col justify-center items-center gap-4">
        <h1 className="font-bold text-3xl">{heading}</h1>
        <h2 className="font-light text-lg text-gray-500">{subHeading}</h2>
        {children}
        <div className="flex gap-1">
          <p>{footerText}</p>
          <a href={footerLinkHref}>{footerLinkText}</a>
        </div>
      </main>
      <footer className="h-10 w-full flex justify-center">
        <p className="text-xs text-gray-500">
          © {new Date().getFullYear()} Sentilens. All rights reserved.
        </p>
      </footer>
    </div>
  );
};

export default AuthLayout;
