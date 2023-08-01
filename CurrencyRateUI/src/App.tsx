import { useContext } from "react";
import "./App.css";
import CurrencyInfo from "./components/CurrencyInfo/CurrencyInfo";
import Details from "./components/Details/Details";
import { DetailsContext } from "./context/details";

function App() {
  const { detailsVisibility } = useContext(DetailsContext);

  return (
    <div className="app">
      <CurrencyInfo className="app_currency-info" />
      {detailsVisibility && <Details className="app__details" />}
    </div>
  );
}

export default App;
