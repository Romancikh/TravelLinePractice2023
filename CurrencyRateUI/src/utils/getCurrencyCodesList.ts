import { Currency } from "../types/Currency";

export default function getCurrencyCodes(currencies: Currency[]): string[] {
  const currencyCodes: string[] = [];
  currencies.forEach((currency) => {
    currencyCodes.push(currency.code);
  });
  return currencyCodes;
}
