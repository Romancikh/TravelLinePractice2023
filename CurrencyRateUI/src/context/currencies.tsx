import { ReactNode, createContext, useState } from "react";
import { Currency } from "../types/Currency";

type CurrenciesContextType = {
  currencies: Currency[];
  setCurrencies: (newCurrencies: Currency[]) => void;
};

export const CurrenciesContext = createContext<CurrenciesContextType>({
  currencies: [],
  setCurrencies: () => {},
});

type CurrenciesProviderProps = {
  children: ReactNode;
};

export function CurrenciesProvider({ children }: CurrenciesProviderProps) {
  const [currencies, setCurrencies] = useState<Currency[]>([]);

  return (
    <CurrenciesContext.Provider
      value={{
        currencies,
        setCurrencies: (newCurrencies) => setCurrencies([...newCurrencies]),
      }}
    >
      {children}
    </CurrenciesContext.Provider>
  );
}
