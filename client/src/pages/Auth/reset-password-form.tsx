import { useState } from "react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import type { IResetUserData } from "@/interfaces/auth";
import { resetPassword } from "@/api/auth";
import { Alert, AlertDescription } from "@/components/ui/alert";
import { CircleAlert } from "lucide-react";

const ResetPasswordForm = () => {
  const [error, setError] = useState<string>("");
  const [isPending, setIsPending] = useState<boolean>(false);
  const [resetPasswordData, setResetPasswordData] = useState<IResetUserData>({
    email: localStorage.getItem("userEmail"),
    otp: null,
    newPassword: "",
    confirmNewPassword: "",
  });

  const handleResetPasswordChange = (
    e: React.ChangeEvent<HTMLInputElement>
  ) => {
    const { name, value } = e.target;
    setResetPasswordData((prevData) => ({ ...prevData, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    console.log(resetPasswordData);

    try {
      if (resetPasswordData.email === null || resetPasswordData.email === "")
        throw new Error("Email cannot be empty!");

      if (
        resetPasswordData.newPassword === null ||
        resetPasswordData.newPassword === ""
      )
        throw new Error("Password cannot be empty!");

      if (
        resetPasswordData.confirmNewPassword === null ||
        resetPasswordData.confirmNewPassword === ""
      )
        throw new Error("Confirm password cannot be empty!");

      if (
        resetPasswordData.newPassword !== resetPasswordData.confirmNewPassword
      )
        throw new Error("Both passwords must match!");

      setIsPending(true);
      const response = await resetPassword(resetPasswordData);
      console.log("Reset Password Form Response: ", await response);
    } catch (err) {
      setIsPending(false);
      if (err instanceof Error) {
        //@ts-expect-error: undefined?
        if (err.response !== undefined) {
          //@ts-expect-error: data
          setError(err.response.data.Errors);
        } else {
          setError(err.message);
        }
      }

      setError("An unexpected error occured trying to Reset Password!");

      await new Promise(() =>
        setTimeout(() => {
          setError("");
        }, 5000)
      );
    }
  };

  return (
    <div className="h-full w-full">
      {error && (
        <Alert variant="destructive" className="border border-red-700 mb-4">
          <CircleAlert className="text-red-700" />
          <AlertDescription className="text-red-700">{error}</AlertDescription>
        </Alert>
      )}

      <form onSubmit={handleSubmit} className="flex flex-col gap-4">
        <Label>OTP</Label>
        <Input
          id="otp"
          name="otp"
          type="number"
          disabled={isPending}
          //@ts-expect-error: null is good... for now
          value={resetPasswordData.otp}
          onChange={handleResetPasswordChange}
          //* hint for some changes maxLength={1}
          placeholder="972474"
        />
        <Label>New Password</Label>
        <Input
          id="newPassword"
          name="newPassword"
          type="password"
          disabled={isPending}
          placeholder="********"
          value={resetPasswordData.newPassword}
          onChange={handleResetPasswordChange}
        />
        <Label>Confirm New Password</Label>
        <Input
          id="confirmNewPassword"
          name="confirmNewPassword"
          type="password"
          disabled={isPending}
          placeholder="********"
          value={resetPasswordData.confirmNewPassword}
          onChange={handleResetPasswordChange}
        />
        <Button
          disabled={isPending}
          size="lg"
          color="default"
          className="cursor-pointer text-md"
        >
          Change Password
        </Button>
      </form>
    </div>
  );
};

export default ResetPasswordForm;
