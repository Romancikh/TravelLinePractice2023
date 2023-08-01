export type Currency = {
  code: string;
  name: string;
  description: string;
  symbol: string;
};

export type CurrencyWithQuantity = Currency & { quantity: number };
