import { useNavigate } from "react-router-dom";

const NotFound = () => {
  const navigate = useNavigate();

  return (
    <div className="flex h-screen flex-col items-center justify-center bg-background p-5 text-center">
      <div className="mb-8 text-9xl font-bold text-primary/20">404</div>
      <h1 className="mb-4 text-4xl font-bold">Page Not Found</h1>
      <p className="mb-8 max-w-md text-muted-foreground">
        The page you're looking for doesn't exist or has been moved.
      </p>
      <div className="flex gap-4">
        <button
          onClick={() => navigate(-1)}
          className="rounded-md border border-border bg-background px-4 py-2 text-foreground transition-colors hover:bg-accent"
        >
          Go Back
        </button>
        <button
          onClick={() => navigate("/")}
          className="rounded-md bg-primary px-4 py-2 text-primary-foreground transition-colors hover:bg-primary/90"
        >
          Go Home
        </button>
      </div>
    </div>
  );
};

export default NotFound;
