import { useContext } from "react";
import "./App.css";
import CurrencyInfo from "./components/CurrencyInfo/CurrencyInfo";
import Details from "./components/Details/Details";
import { DescriptionContext } from "./context/description";

function App() {
  const { descriptionVisibility } = useContext(DescriptionContext);

  return (
    <div className="app">
      <CurrencyInfo className="app_currency-info" />
      {descriptionVisibility && <Details className="app__details" />}
    </div>
  );
}

export default App;
