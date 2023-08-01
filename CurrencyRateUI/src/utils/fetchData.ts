import { Currency } from "../types/Currency";
import { Price } from "../types/Price";

export async function fetchCurrencies(): Promise<Currency[]> {
  const response = await fetch("api/Currencies");
  return response.json();
}

export async function fetchCurrency(code: string): Promise<Currency> {
  const response = await fetch(`api/Currencies/${code}`);
  return response.json();
}

export async function fetchPrices(
  paymentCurrency: string,
  purchasedCurrency: string,
  fromDateTime: Date
): Promise<Price[]> {
  if (paymentCurrency && purchasedCurrency && fromDateTime) {
    const response = await fetch(
      "api/prices/?" +
        new URLSearchParams({
          PaymentCurrency: paymentCurrency,
          PurchasedCurrency: purchasedCurrency,
          FromDateTime: fromDateTime.toISOString(),
        })
    );
    return response.json();
  }
  return [];
}
