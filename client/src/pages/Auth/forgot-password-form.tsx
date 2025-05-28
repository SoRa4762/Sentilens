import { forgotPassword } from "@/api/auth";
import { Alert, AlertDescription } from "@/components/ui/alert";
import { Button } from "@/components/ui/button";
// import {
//   Dialog,
//   DialogContent,
//   DialogDescription,
//   DialogHeader,
//   DialogTitle,
//   DialogTrigger,
// } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { CheckCircle2, CircleAlert } from "lucide-react";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

const ForgotPasswordForm = () => {
  const [email, setEmail] = useState<string>("");
  const [isPending, setIsPending] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  // const [dialogTrigger, setDialogTrigger] = useState<boolean>(false);
  const [isSuccess, setIsSuccess] = useState<boolean>(false);
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      if (email === "" || email === null)
        throw new Error("Email cannot be empty!");

      setIsPending(true);
      const doForgetPassword = await forgotPassword(email);
      if (doForgetPassword) {
        setIsSuccess(true);
        //for some delay, to show UI and make the process authentic
        await new Promise((resolve) => {
          setTimeout(resolve, 1000);
        });

        localStorage.setItem("userEmail", email);

        navigate("/reset-password");
      }
    } catch (err) {
      setIsPending(false);

      if (err instanceof Error) {
        console.log("Forgot Password Error: ", err);
        //@ts-expect-error: not ok
        if (err.response === undefined) {
          setError(err.message);
        } else {
          //@ts-expect-error: ok
          setError(err.response.data.Errors);
        }
      }

      setError("An unexpected error occured trying Forgot Password!");

      await new Promise(() =>
        setTimeout(() => {
          setError("");
        }, 5000)
      );
    }
  };

  return (
    <div className="flex flex-col gap-4 items-center h-full w-full">
      {/* modal - didn't work as expected! */}
      {/* <Dialog>
        <DialogTrigger>{dialogTrigger}</DialogTrigger> // didn't trigger
        <DialogContent>
          <DialogHeader>
            <DialogTitle>OTP Sent Successfully!</DialogTitle>
            <DialogDescription>
              Your OTP has been successfully sent to the given email!
            </DialogDescription>
          </DialogHeader>
        </DialogContent>
      </Dialog> */}
      {/* error */}
      {error && (
        <Alert variant="destructive" className="border border-red-700">
          <CircleAlert className="text-red-700" />
          <AlertDescription className="text-red-700">{error}</AlertDescription>
        </Alert>
      )}

      {isSuccess ? (
        <>
          <Alert className="border border-green-700">
            <CheckCircle2 className="text-green-700" />
            <AlertDescription className="text-green-700">
              If an account exists for {email}, we've sent password reset
              instructions to that email address.
            </AlertDescription>
          </Alert>
        </>
      ) : (
        <form
          onSubmit={handleSubmit}
          className="h-full w-full flex flex-col gap-4"
        >
          <Label>Email</Label>
          <Input
            type="email"
            placeholder="email@gmail.com"
            value={email}
            disabled={isPending}
            onChange={(e) => {
              setEmail(e.target.value);
            }}
          />
          <Button
            color="default"
            size="lg"
            className="cursor-pointer text-md"
            disabled={isPending}
          >
            Send reset instructions
          </Button>
        </form>
      )}
    </div>
  );
};

export default ForgotPasswordForm;
