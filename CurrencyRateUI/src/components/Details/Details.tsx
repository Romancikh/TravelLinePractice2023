import "./Details.css";

type DetailsProps = {
  className?: string;
};

function Details({ className }: DetailsProps) {
  return (
    <div className={`details ${className}`}>
      <div className="currency-details details__currency-details">
        <div className="currency-details__heading">Heading 1</div>
        <div className="currency-details__description">Some description</div>
      </div>
      <div className="currency-details details__currency-details">
        <div className="currency-details__heading">Heading 1</div>
        <div className="currency-details__description">Some description</div>
      </div>
    </div>
  );
}

export default Details;
