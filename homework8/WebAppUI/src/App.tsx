import React, { useEffect, useState } from 'react';
import axios from 'axios';
import CurrencyConverterForm from './CurrencyConverterForm';

interface Currency {
  code: string;
  name: string;
}

const App: React.FC = () => {
  const [currencies, setCurrencies] = useState<Currency[]>([]);

  useEffect(() => {
    const fetchCurrencies = async () => {
      try {
        const response = await axios.get<Currency[]>('http://localhost:5000/currencies');
        setCurrencies(response.data);
      } catch (error) {
        console.error('Ошибка при получении списка валют:', error);
      }
    };
    fetchCurrencies();
  }, []);

  return (
    <React.StrictMode>
      <div>
        <h1>Currency Converter</h1>
        {currencies.length > 0 ? (
          <CurrencyConverterForm currencies={currencies} />
        ) : (
          <p>Загрузка...</p>
        )}
      </div>
    </React.StrictMode>
  );
};

export default App;
