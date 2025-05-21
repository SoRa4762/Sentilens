import { Button } from "@/components/ui/button";
import { FaFacebook, FaGoogle } from "react-icons/fa6";

const SocialLoginButtons = () => {
  return (
    <div className="flex h-16 w-full items-center justify-center gap-4">
      <Button className="w-1/2 bg-white text-black font-medium border border-gray-300 hover:bg-gray-100 cursor-pointer">
        <FaGoogle />
        Google
      </Button>
      <Button className="w-1/2 bg-white text-black font-medium border border-gray-300 hover:bg-gray-100 cursor-pointer">
        <FaFacebook />
        Facebook
      </Button>
    </div>
  );
};

export default SocialLoginButtons;
