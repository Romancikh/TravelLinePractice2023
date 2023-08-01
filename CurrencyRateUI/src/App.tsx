import "./App.css";
import CurrencyInfo from "./components/CurrencyInfo/CurrencyInfo";
import Details from "./components/Details/Details";
import { CurrenciesProvider } from "./context/currencies";
import { DescriptionProvider } from "./context/description";
import { SelectedCurrenciesProvider } from "./context/selectedCurrencies";

function App() {
  return (
    <SelectedCurrenciesProvider>
      <CurrenciesProvider>
        <DescriptionProvider>
          <div className="app">
            <CurrencyInfo className="app_currency-info" />
            <Details className="app__details" />
          </div>
        </DescriptionProvider>
      </CurrenciesProvider>
    </SelectedCurrenciesProvider>
  );
}

export default App;
