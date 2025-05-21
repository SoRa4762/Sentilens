const FormDivider = ({ text }: { text: string }) => {
  return (
    // <div className="h-8 w-full flex justify-center items-center">
    //   <span className="font-light text-gray-500 uppercase text-sm">{text}</span>
    // </div>
    <div className="relative">
      <div className="absolute inset-0 flex items-center">
        <div className="w-full border-t border-gray-200" />
      </div>
      <div className="relative flex justify-center text-xs uppercase">
        <span className="bg-white px-2 text-gray-500">{text}</span>
      </div>
    </div>
  );
};

export default FormDivider;
