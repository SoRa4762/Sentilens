import React from "react";
import SocialLoginButtons from "./social-login-buttons";
import FormDivider from "./form-divider";
import { Button } from "@/components/ui/button";
import { Checkbox } from "@/components/ui/checkbox";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";

type Props = {};

const SigninForm = (props: Props) => {
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
  };

  return (
    <div className="h-full w-full flex flex-col gap-6">
      <SocialLoginButtons />
      <FormDivider text="Or continue with" />

      <form onSubmit={handleSubmit} className="flex flex-col gap-5">
        <Label htmlFor="email" className="text-sm font-medium">
          Email
        </Label>
        <Input id="email" type="email" placeholder="name@gmail.com" />
        <Label htmlFor="password" className="text-sm font-medium">
          Password
        </Label>
        <Input id="password" type="email" placeholder="name@gmail.com" />
        <span className="flex gap-2">
          <Checkbox />
          <Label>Remember Me</Label>
        </span>
        <Button
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
