import { useContext, useEffect, useState } from "react";
import Selector from "../Selector/Selector";
import "./CurrencyInfo.css";
import { CurrenciesContext } from "../../context/currencies";
import getCurrencyCodes from "../../utils/getCurrencyCodesList";

type CurrencyInfoProps = {
  className: string;
};

function CurrencyInfo({ className }: CurrencyInfoProps) {
  const { currencies } = useContext(CurrenciesContext);

  const [options, setOptions] = useState<string[]>([]);

  useEffect(() => {
    setOptions(getCurrencyCodes(currencies));
  }, [currencies]);

  return (
    <div className={`currency-info ${className}`}>
      <div className="currency-info__summary">
        <h2 className="first-currency">1 {"Loading..."} equals</h2>
        <h1 className="second-currency">
          {1} {"Loading..."}
        </h1>
        <span className="update-time">{"updateDate"}</span>
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
      <button className="button currency-info__button">More details</button>
    </div>
  );
}

export default CurrencyInfo;
