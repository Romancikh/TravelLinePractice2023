import { ReactNode, createContext, useState } from "react";
import { Currency } from "../types/Currency";

const defaultCurrency: Currency = {
  code: "",
  name: "",
  description: "",
  symbol: "",
  quantity: 0,
};

type SelectedCurrenciesContextType = {
  payment: Currency;
  purchased: Currency;
  setPayment: (newCurrency: Currency) => void;
  setPurchased: (newCurrency: Currency) => void;
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
  const [payment, setPayment] = useState<Currency>(defaultCurrency);
  const [purchased, setPurchased] = useState<Currency>(defaultCurrency);

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
