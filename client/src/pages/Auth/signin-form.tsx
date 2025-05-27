import React, { useState } from "react";
import SocialLoginButtons from "./social-login-buttons";
import FormDivider from "./form-divider";
import { Button } from "@/components/ui/button";
import { Checkbox } from "@/components/ui/checkbox";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
import { AlertCircle } from "lucide-react";
import { useNavigate } from "react-router-dom";
import type { ISignInForm, IUserData } from "@/interfaces/auth";
import { signin } from "@/api/auth";

const SigninForm = () => {
  const navigate = useNavigate();
  const [error, setError] = useState<string | null>(null);
  const [isPending, setIsPending] = useState<boolean>(false);
  const [formData, setFormData] = useState<ISignInForm>({
    email: "",
    password: "",
    rememberMe: false,
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleCheckBoxChange = (checked: boolean) => {
    setFormData((prev) => ({ ...prev, rememberMe: checked }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    console.log(formData);
    try {
      // await new Promise((resolve) => setTimeout(resolve, 1000));
      // setIsPending(false);

      if (formData.email === null || formData.email === "")
        throw new Error("Email is required!");

      if (!formData.email.includes("@"))
        throw new Error("Please enter a vaid email address!");

      if (formData.password === null || formData.password === "")
        throw new Error("Password is required!");

      if (formData.password.length < 8)
        throw new Error("Password length should be more than 8 characters");

      // signin - try catch
      setIsPending(true);
      try {
        const doSignin = await signin(formData);
        const data = await doSignin;
        if (!data.data.Errors) {
          console.log(data.data);

          const userData: IUserData = {
            userId: data.data.Id,
            email: data.data.Email,
            username: data.data.UserName,
            token: data.data.Token,
          };

          localStorage.setItem("userData", JSON.stringify(userData));
          navigate("/");
        } else {
          throw new Error(data.data.Errors);
        }
      } catch (err) {
        setIsPending(false);
        console.log(err);
        setError(
          err instanceof Error
            ? // @ts-expect-error: Unreachable code error
              err.response.data.Errors
            : "An unexpected error occured when logging in"
        );

        // setError(
        //   typeof err === "string"
        //     ? err
        //     : "An unexpected error occured when logging in"
        // );
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
    <div className="h-full w-full flex flex-col gap-6">
      <SocialLoginButtons isPending={isPending} />
      <FormDivider text="Or continue with" />
      {error && (
        <Alert variant="destructive" className="border border-red-700">
          <AlertCircle className="text-red-700" />
          {/* <AlertTitle className="text-red-700">Error</AlertTitle> */}
          <AlertDescription className="text-red-700">{error}</AlertDescription>
        </Alert>
      )}

      <form onSubmit={handleSubmit} className="flex flex-col gap-5">
        <Label htmlFor="email" className="text-sm font-medium">
          Email
        </Label>
        <Input
          onChange={handleChange}
          id="email"
          name="email"
          type="email"
          placeholder="name@gmail.com"
          value={formData.email}
          disabled={isPending}
        />
        <div className="flex justify-between items-end">
          <Label htmlFor="password" className="text-sm font-medium">
            Password
          </Label>
          <a href="/forgot-password" className="text-xs">
            Forgot Password?
          </a>
        </div>
        <Input
          onChange={handleChange}
          id="password"
          name="password"
          type="password"
          placeholder="********"
          value={formData.password}
          disabled={isPending}
        />
        <span className="flex gap-2">
          <Checkbox
            checked={formData.rememberMe}
            onCheckedChange={handleCheckBoxChange}
            disabled={isPending}
          />
          <Label>Remember Me</Label>
        </span>
        <Button
          disabled={isPending}
          className="h-10 cursor-pointer"
          onClick={(e: React.FormEvent) => handleSubmit(e)}
        >
          Sign In
        </Button>
      </form>
    </div>
  );
};

export default SigninForm;
