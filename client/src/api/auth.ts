import type {
  IForgotPassword,
  IResetPassword,
  ISignInForm,
  ISignUpForm,
} from "@/interfaces/auth";
import axios from "axios";

const baseUrl = "https://localhost:7143/api/v1/User";

const signin = async ({ email, password, rememberMe }: ISignInForm) => {
  const response = await axios.post(`${baseUrl}/login`, {
    email,
    password,
    rememberMe,
  });

  return response;
};

const signup = async ({ username, email, password }: ISignUpForm) => {
  const response = await axios.post(`${baseUrl}/register`, {
    username,
    email,
    password,
  });

  return response;
};

const twoFactor = async () => {};

const forgotPassword = async (email: string) => {
  const response = await axios.post(`${baseUrl}/forgot-password`, {
    email,
  });

  return response;
};

const resetPassword = async () => {};

export { signin, signup, twoFactor, resetPassword, forgotPassword };
