import "./Selector.css";

type SelectorProps = {
  className?: string;
};

function Selector({ className }: SelectorProps) {
  return (
    <>
      <div className={`selector ${className}`}>
        <input
          type="number"
          name={`Input`}
          id={`Input`}
          min={0}
          className="selector__input"
        />
        <div className="selector__divisor" />
        <select
          name={`Select`}
          id={`Select`}
          className="selector__select"
        ></select>
      </div>
    </>
  );
}

export default Selector;
