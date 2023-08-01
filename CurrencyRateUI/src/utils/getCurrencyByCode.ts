import { Currency } from "../types/Currency";

export default function getCurrencyByCode(
  currencies: Currency[],
  code: string
): Currency {
  return currencies.filter((currency) => currency.code === code)[0];
}
