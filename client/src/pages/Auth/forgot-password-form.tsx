import { forgotPassword } from "@/api/auth";
import { Alert, AlertDescription } from "@/components/ui/alert";
import { Button } from "@/components/ui/button";
import type { IForgotPassword } from "@/interfaces/auth";
import { CircleAlert } from "lucide-react";
import { useState } from "react";

const ForgotPasswordForm = () => {
  const [email, setEmail] = useState<IForgotPassword>("");
  const [isPending, setIsPending] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const doForgetPassword = await forgotPassword(email);
  };

  return (
    <div className="flex flex-col gap-4 items-center">
      {error && (
        <Alert>
          <CircleAlert />
          <AlertDescription className="text-red-700">{error}</AlertDescription>
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <input
          type="email"
          placeholder="email@gmail.com"
          value={email}
          disabled={isPending}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
        <Button disabled={isPending}>Send reset instructions</Button>
      </form>
    </div>
  );
};

export default ForgotPasswordForm;
