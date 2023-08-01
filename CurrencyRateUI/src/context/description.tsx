import { ReactNode, createContext, useState } from "react";

type DescriptionContextType = {
  descriptionVisibility: boolean;
  setDescriptionVisibility: (newState: boolean) => void;
};

export const DescriptionContext = createContext<DescriptionContextType>({
  descriptionVisibility: false,
  setDescriptionVisibility: () => {},
});

type DescriptionProviderProps = {
  children: ReactNode;
};

export function DescriptionProvider({ children }: DescriptionProviderProps) {
  const [descriptionVisibility, setDescriptionVisibility] =
    useState<boolean>(false);

  return (
    <DescriptionContext.Provider
      value={{
        descriptionVisibility,
        setDescriptionVisibility: (newState) =>
          setDescriptionVisibility(newState),
      }}
    >
      {children}
    </DescriptionContext.Provider>
  );
}
