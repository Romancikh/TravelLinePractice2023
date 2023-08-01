import { useContext, useEffect, useState } from "react";
import Selector from "../Selector/Selector";
import "./CurrencyInfo.css";
import { CurrenciesContext } from "../../context/currencies";
import getCurrencyCodes from "../../utils/getCurrencyCodesList";
import { DetailsContext } from "../../context/details";
import { SelectedCurrenciesContext } from "../../context/selectedCurrencies";
import useExchangeRate from "../../hooks/useExchangeRate";

type CurrencyInfoProps = {
  className: string;
};

function CurrencyInfo({ className }: CurrencyInfoProps) {
  const { currencies } = useContext(CurrenciesContext);
  const { detailsVisibility, setDetailsVisibility } =
    useContext(DetailsContext);
  const { payment, purchased } = useContext(SelectedCurrenciesContext);

  const [options, setOptions] = useState<string[]>([]);

  const [exchangeRate, exchangeDate] = useExchangeRate(
    payment.code,
    purchased.code
  );

  useEffect(() => {
    setOptions(getCurrencyCodes(currencies));
  }, [currencies]);

  return (
    <div className={`currency-info ${className}`}>
      <div className="currency-info__summary">
        <h2 className="payment-currency">
          1 {payment.name ?? "Loading..."} equals
        </h2>
        <h1 className="purchased-currency">
          {exchangeRate} {purchased.name ?? "Loading..."}
        </h1>
        <span className="update-time">
          {new Date(exchangeDate).toLocaleString()}
        </span>
      </div>
      <div className="currency-info__selector-container">
        <Selector
          id="payment"
          options={options}
          className="currency-info__selector"
        />
        <Selector
          id="purchased"
          options={options}
          className="currency-info__selector"
        />
      </div>
      <button
        className="button currency-info__button"
        onClick={() => setDetailsVisibility(!detailsVisibility)}
      >
        {detailsVisibility ? "Less" : "More"} details
      </button>
    </div>
  );
}

export default CurrencyInfo;
