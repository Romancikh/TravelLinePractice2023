import { useState, useEffect } from "react";
import { fetchPrices } from "../utils/fetchData";

export default function useExchangeRate(
  payment: string,
  purchased: string
) {
  const [exchangeRate, setExchangeRate] = useState(0);
  const [exchangeDate, setExchangeDate] = useState("");

  useEffect(() => {
    const getPrice = async () => {
      const price = (
        await fetchPrices(payment, purchased, new Date(-10000))
      ).pop();
      if (price) {
        setExchangeRate(price.price);
        setExchangeDate(price.dateTime);
      }
    };

    getPrice();

    const intervalId = setInterval(getPrice, 10000);

    return () => clearInterval(intervalId);
  }, [payment, purchased]);

  return [exchangeRate, exchangeDate];
}
