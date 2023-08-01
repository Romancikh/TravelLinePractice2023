import "./CurrencyInfoSummary.css";

type CurrencyInfoSummaryProps = {
  firstCurrency?: string;
  secondCurrency?: string;
  currencyRate: number;
  updateDate: string;
};

function CurrencyInfoSummary({
  firstCurrency,
  secondCurrency,
  currencyRate,
  updateDate,
}: CurrencyInfoSummaryProps) {
  return (
    <div className="currency-info__summary">
      <h2 className="first-currency">
        1 {firstCurrency ?? "Loading..."} equals
      </h2>
      <h1 className="second-currency">
        {currencyRate} {secondCurrency ?? "Loading..."}
      </h1>
      <span className="update-time">{updateDate}</span>
    </div>
  );
}

export default CurrencyInfoSummary;
