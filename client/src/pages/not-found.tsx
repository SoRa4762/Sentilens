import { Link } from "react-router-dom";
import { Button } from "@/components/ui/button";
import { Home, Search, HelpCircle } from "lucide-react";
import { SentilensLogo } from "@/components/sentilens-logo";

export default function NotFound() {
  return (
    <div className="flex min-h-screen flex-col bg-gradient-to-b from-gray-50 to-white">
      <header className="border-b bg-white">
        <div className="container flex h-16 items-center justify-between px-4 md:px-6">
          <Link to="/" className="flex items-center gap-2">
            <SentilensLogo className="h-8 w-8" />
            <span className="text-xl font-bold">Sentilens</span>
          </Link>
        </div>
      </header>

      <main className="container flex flex-1 flex-col items-center justify-center px-4 py-12 text-center md:px-6 md:py-24">
        <div className="relative mb-8 h-40 w-40 overflow-hidden rounded-full border-4 border-gray-100 bg-white shadow-xl">
          <div className="absolute inset-0 flex items-center justify-center bg-gradient-to-br from-blue-50 to-indigo-50">
            <div className="text-8xl font-light text-primary/80">404</div>
          </div>
        </div>

        <h1 className="mb-4 text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl">
          Page Not Found
        </h1>

        <p className="mb-8 max-w-[600px] text-gray-500 md:text-xl/relaxed lg:text-base/relaxed xl:text-xl/relaxed">
          We couldn't find the page you're looking for. The link might be
          incorrect, the page may have moved, or it no longer exists.
        </p>

        <div className="flex flex-col gap-4 sm:flex-row">
          <Button size="lg" className="gap-2" asChild>
            <Link to="/">
              <Home className="h-5 w-5" />
              Return to Home
            </Link>
          </Button>
          <Button variant="outline" size="lg" className="gap-2" asChild>
            <Link to="/articles">
              <Search className="h-5 w-5" />
              Browse Articles
            </Link>
          </Button>
        </div>

        <div className="mt-12 flex flex-col items-center space-y-4 rounded-lg border bg-white p-6 shadow-sm">
          <h2 className="text-xl font-semibold">
            Looking for something specific?
          </h2>
          <div className="flex flex-wrap justify-center gap-3">
            <Button variant="ghost" size="sm" className="gap-2" asChild>
              <Link to="/dashboard">Dashboard</Link>
            </Button>
            <Button variant="ghost" size="sm" className="gap-2" asChild>
              <Link to="/profile">Profile</Link>
            </Button>
            <Button variant="ghost" size="sm" className="gap-2" asChild>
              <Link to="/settings">Settings</Link>
            </Button>
            <Button variant="ghost" size="sm" className="gap-2" asChild>
              <Link to="/help">
                <HelpCircle className="h-4 w-4" />
                Help Center
              </Link>
            </Button>
          </div>
        </div>
      </main>

      <footer className="border-t bg-white py-6">
        <div className="container flex flex-col items-center justify-between gap-4 px-4 text-center md:flex-row md:text-left">
          <p className="text-sm text-gray-500">
            © {new Date().getFullYear()} Sentilens. All rights reserved.
          </p>
          <div className="flex gap-4">
            <Button variant="link" size="sm" asChild>
              <Link to="/">Home</Link>
            </Button>
            <Button variant="link" size="sm" asChild>
              <Link to="/contact">Contact</Link>
            </Button>
            <Button variant="link" size="sm" asChild>
              <Link to="/help">Help</Link>
            </Button>
          </div>
        </div>
      </footer>
    </div>
  );
}
