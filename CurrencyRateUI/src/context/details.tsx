import { ReactNode, createContext, useState } from "react";

type DetailsContextType = {
  detailsVisibility: boolean;
  setDetailsVisibility: (newState: boolean) => void;
};

export const DetailsContext = createContext<DetailsContextType>({
  detailsVisibility: false,
  setDetailsVisibility: () => {},
});

type DetailsProviderProps = {
  children: ReactNode;
};

export function DetailsProvider({ children }: DetailsProviderProps) {
  const [detailsVisibility, setDetailsVisibility] = useState<boolean>(false);

  return (
    <DetailsContext.Provider
      value={{
        detailsVisibility,
        setDetailsVisibility: (newState) => setDetailsVisibility(newState),
      }}
    >
      {children}
    </DetailsContext.Provider>
  );
}
