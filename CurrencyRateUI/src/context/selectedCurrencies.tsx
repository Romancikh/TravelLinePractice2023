import { ReactNode, createContext, useState } from "react";
import { CurrencyWithQuantity } from "../types/Currency";

const defaultCurrency: CurrencyWithQuantity = {
  code: "",
  name: "",
  description: "",
  symbol: "",
  quantity: 0,
};

type SelectedCurrenciesContextType = {
  payment: CurrencyWithQuantity;
  purchased: CurrencyWithQuantity;
  setPayment: (newCurrency: CurrencyWithQuantity) => void;
  setPurchased: (newCurrency: CurrencyWithQuantity) => void;
};

export const SelectedCurrenciesContext =
  createContext<SelectedCurrenciesContextType>({
    payment: defaultCurrency,
    purchased: defaultCurrency,
    setPayment: () => {},
    setPurchased: () => {},
  });

type SelectedCurrenciesProviderProps = {
  children: ReactNode;
};

export function SelectedCurrenciesProvider({
  children,
}: SelectedCurrenciesProviderProps) {
  const [payment, setPayment] = useState<CurrencyWithQuantity>(defaultCurrency);
  const [purchased, setPurchased] =
    useState<CurrencyWithQuantity>(defaultCurrency);

  return (
    <SelectedCurrenciesContext.Provider
      value={{
        payment,
        purchased,
        setPayment: (newCurrency) => setPayment({ ...newCurrency }),
        setPurchased: (newCurrency) => setPurchased({ ...newCurrency }),
      }}
    >
      {children}
    </SelectedCurrenciesContext.Provider>
  );
}
