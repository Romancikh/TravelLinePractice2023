import { useContext } from "react";
import "./Details.css";
import { SelectedCurrenciesContext } from "../../context/selectedCurrencies";

type DetailsProps = {
  className?: string;
};

function Details({ className }: DetailsProps) {
  const { payment, purchased } = useContext(SelectedCurrenciesContext);

  return (
    <div className={`details ${className}`}>
      <div className="currency-details details__currency-details">
        <div className="currency-details__heading">
          {payment.name}, {payment.symbol}
        </div>
        <div className="currency-details__description">
          {payment.description}
        </div>
      </div>
      <div className="currency-details details__currency-details">
        <div className="currency-details__heading">
          {purchased.name}, {purchased.symbol}
        </div>
        <div className="currency-details__description">
          {purchased.description}
        </div>
      </div>
    </div>
  );
}

export default Details;
