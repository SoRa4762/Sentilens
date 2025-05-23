import { Alert, AlertDescription } from "@/components/ui/alert";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import type { ISignUpForm } from "@/interfaces/auth";
import { CircleAlert } from "lucide-react";
import { useState } from "react";
import SocialLoginButtons from "./social-login-buttons";
import FormDivider from "./form-divider";
import { signup } from "@/api/auth";
import { useNavigate } from "react-router-dom";
import Loader from "@/components/common/Loader";

const SignupForm = () => {
  const navigate = useNavigate();
  const [error, setError] = useState<string | null>(null);
  const [isPending, setIsPending] = useState<boolean>(false);
  const [formData, setFormData] = useState<ISignUpForm>({
    username: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      if (formData.username === null || formData.username === "")
        throw new Error("Username is required!");

      if (formData.email === null || formData.email === "")
        throw new Error("Email is required!");

      if (!formData.email.includes("@"))
        throw new Error("Please enter a vaid email address!");

      if (formData.password === null || formData.password === "")
        throw new Error("Password is required!");

      if (formData.password.length < 8)
        throw new Error("Password length should be more than 8 characters");

      if (formData.confirmPassword !== formData.password)
        throw new Error("Passwords do not match!");

      setIsPending(true);
      try {
        const doSignUp = await signup(formData);
        const response = await doSignUp.data;

        if (!response) throw new Error("Error tring to sign up user!");
        await new Promise((resolve) => setTimeout(resolve, 1000));
        <Loader />;
        navigate("/signin");
      } catch (err) {
        setIsPending(false);
        setError(
          err instanceof Error
            ? //@ts-expect-error: I know better bruh
              err.response.data.Errors
            : "An Error Occured trying to Sign Up"
        );
      }
    } catch (err) {
      setError(
        err instanceof Error
          ? err.message
          : "An unexpected error occured when submitting the form"
      );
    }
  };

  return (
    <>
      <div className="h-full w-full flex flex-col gap-4">
        <SocialLoginButtons isPending={isPending} />
        <FormDivider text="Or continue with" />

        {error && (
          <Alert>
            <CircleAlert />
            <AlertDescription className="text-red-700">
              {error}
            </AlertDescription>
          </Alert>
        )}

        <form onSubmit={handleSubmit} className="flex flex-col gap-4">
          <Label htmlFor="username">Username</Label>
          <Input
            name="username"
            id="username"
            type="text"
            disabled={isPending}
            onChange={handleInputChange}
          />
          <Label htmlFor="email">Email</Label>
          <Input
            id="email"
            name="email"
            type="email"
            disabled={isPending}
            onChange={handleInputChange}
          />
          <Label htmlFor="password">Password</Label>
          <Input
            id="password"
            name="password"
            type="password"
            disabled={isPending}
            onChange={handleInputChange}
          />
          <Label htmlFor="confirmPassword">Confirm Password</Label>
          <Input
            id="confirmPassword"
            name="confirmPassword"
            type="password"
            disabled={isPending}
            onChange={handleInputChange}
          />
          <Button
            type="submit"
            disabled={isPending}
            className="w-full cursor-pointer"
          >
            Sign Up
          </Button>
        </form>
      </div>
    </>
  );
};

export default SignupForm;
