import { ChangeEvent, useContext, useEffect } from "react";
import "./Selector.css";
import { SelectedCurrenciesContext } from "../../context/selectedCurrencies";
import getCurrencyByCode from "../../utils/getCurrencyByCode";
import { CurrenciesContext } from "../../context/currencies";

type SelectorProps = {
  id: "payment" | "purchased";
  options: string[];
  exchangeRate: number;
  className?: string;
};

function Selector({ id, options, exchangeRate, className }: SelectorProps) {
  const { payment, purchased, setPayment, setPurchased } = useContext(
    SelectedCurrenciesContext
  );
  const { currencies } = useContext(CurrenciesContext);

  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const quantity = parseFloat(parseFloat(event.target.value).toFixed(3));
    if (id === "payment") {
      if (!isNaN(quantity)) {
        setPayment({ ...payment, quantity });
        setPurchased({
          ...purchased,
          quantity: parseFloat((quantity * exchangeRate).toFixed(3)),
        });
      } else {
        setPayment({ ...payment, quantity: 0 });
        setPurchased({ ...purchased, quantity: 0 });
      }
    } else {
      if (!isNaN(quantity)) {
        setPurchased({ ...purchased, quantity });
        setPayment({
          ...payment,
          quantity: parseFloat((quantity / exchangeRate).toFixed(3)),
        });
      } else {
        setPurchased({ ...purchased, quantity: 0 });
      }
    }
  };

  const handleSelectChange = (event: ChangeEvent<HTMLSelectElement>) => {
    const newCurrency = getCurrencyByCode(currencies, event.target.value);
    if (id === "payment") {
      setPayment({ ...newCurrency, quantity: payment.quantity });
    } else {
      setPurchased({ ...newCurrency, quantity: purchased.quantity });
    }
  };

  useEffect(() => {
    if (id === "payment") {
      setPayment({ ...currencies[0], quantity: 0 });
    } else {
      setPurchased({ ...currencies[0], quantity: 0 });
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id, currencies]);

  useEffect(() => {
    setPurchased({
      ...purchased,
      quantity: parseFloat((payment.quantity * exchangeRate).toFixed(3)),
    });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [exchangeRate]);

  return (
    <>
      <div className={`selector ${className}`}>
        <input
          type="number"
          id={`${id}Input`}
          min={0}
          value={(id === "payment" ? payment.quantity : purchased.quantity)
            .toString()
            .replace(/^0{2,}/, "")}
          className="selector__input"
          onChange={handleInputChange}
        />
        <div className="selector__divisor" />
        <select
          id={`${id}Select`}
          value={id === "payment" ? payment.code : purchased.code}
          className="selector__select"
          onChange={handleSelectChange}
        >
          {options.map((option) => (
            <option key={option}>{option}</option>
          ))}
        </select>
      </div>
    </>
  );
}

export default Selector;
