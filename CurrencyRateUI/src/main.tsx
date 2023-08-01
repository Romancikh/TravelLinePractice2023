import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
import { DescriptionProvider } from "./context/description.tsx";
import { CurrenciesProvider } from "./context/currencies.tsx";
import { SelectedCurrenciesProvider } from "./context/selectedCurrencies.tsx";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <SelectedCurrenciesProvider>
      <CurrenciesProvider>
        <DescriptionProvider>
          <App />
        </DescriptionProvider>
      </CurrenciesProvider>
    </SelectedCurrenciesProvider>
  </React.StrictMode>
);
