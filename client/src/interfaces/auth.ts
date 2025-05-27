export interface ISignInForm {
  email: string;
  password: string;
  rememberMe: boolean;
}

export interface ISignUpForm {
  username: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface IUserData {
  userId: string;
  email: string;
  username: string;
  token: string;
}

export interface IResetPassword {
  email: string;
}
