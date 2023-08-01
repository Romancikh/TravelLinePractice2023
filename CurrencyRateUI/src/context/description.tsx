import { ReactNode, createContext, useState } from "react";

type DescriptionContextType = {
  visibility: boolean;
  setVisibility: (newState: boolean) => void;
};

export const DescriptionContext = createContext<DescriptionContextType>({
  visibility: false,
  setVisibility: () => {},
});

type DescriptionProviderProps = {
  children: ReactNode;
};

export function DescriptionProvider({ children }: DescriptionProviderProps) {
  const [visibility, setVisibility] = useState<boolean>(false);

  return (
    <DescriptionContext.Provider
      value={{
        visibility,
        setVisibility: (newState) => setVisibility(newState),
      }}
    >
      {children}
    </DescriptionContext.Provider>
  );
}
