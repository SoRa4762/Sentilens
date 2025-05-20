import type { FC } from "react";

interface SentilensLogoProps {
  className?: string;
}

export const SentilensLogo: FC<SentilensLogoProps> = ({ className }) => {
  return (
    <div
      className={`relative flex items-center justify-center rounded-full bg-gradient-to-br from-blue-500 to-purple-600 ${className}`}
    >
      <div className="absolute inset-0 flex items-center justify-center">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          strokeWidth="2"
          strokeLinecap="round"
          strokeLinejoin="round"
          className="h-1/2 w-1/2 text-white"
        >
          <path d="M2 12h5" />
          <path d="M9 12h5" />
          <path d="M16 12h6" />
          <path d="M3 7h7" />
          <path d="M13 7h3" />
          <path d="M19 7h2" />
          <path d="M3 17h2" />
          <path d="M8 17h8" />
          <path d="M19 17h2" />
        </svg>
      </div>
    </div>
  );
};
