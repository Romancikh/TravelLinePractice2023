import "./App.css";
import CurrencyInfo from "./components/CurrencyInfo/CurrencyInfo";
import Details from "./components/Details/Details";

function App() {
  return (
    <div className="app">
      <CurrencyInfo className="app_currency-info" />
      <Details className="app__details" />
    </div>
  );
}

export default App;
