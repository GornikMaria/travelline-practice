import React, { useState, useEffect } from 'react';
import axios, { Axios, AxiosResponse } from 'axios';

interface Currency {
  code: string;
  name: string;
}

interface CurrencyConverterFormProps {
  currencies: Currency[];
}

const CurrencyConverterForm: React.FC<CurrencyConverterFormProps> = ({ currencies }) => {
  const [sourceAmount, setSourceAmount] = useState<string>('0');
  const [targetAmount, setTargetAmount] = useState<number>(0);
  const [sourceCurrency, setSourceCurrency] = useState<Currency>(currencies[0]);
  const [targetCurrency, setTargetCurrency] = useState<Currency>(currencies[1]);
  const [exchangeRate, setExchangeRate] = useState<number>(0.011);

  const fetchExchangeRate = () => {
    axios
      .get(
        `http://localhost:5000/prices?PaymentCurrency=${sourceCurrency.code}&PurchasedCurrency=${targetCurrency.code}`
      )
      .then((response: AxiosResponse) => {
        const exchangeRate = response.data[response.data.length-1].price;
        //console.log(exchangeRate);
        console.log(response.data);
        setExchangeRate(exchangeRate);
        
        const calculatedAmount = isNaN(parseFloat(sourceAmount)) ? 0 : parseFloat(sourceAmount) * exchangeRate;
        if (!isNaN(calculatedAmount)) {
          setTargetAmount(calculatedAmount);
        }
      })
      .catch((error) => {
        console.error('Ошибка при получении данных с сервера:', error);
      });
  };

  useEffect(() => {
    fetchExchangeRate();
    //каждые 10 секунд
    const interval = setInterval(fetchExchangeRate, 10000);
    return () => clearInterval(interval);
  }, [sourceCurrency, targetCurrency]);

  const handleSourceAmountChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const amount = parseFloat(event.target.value);
    setSourceAmount(isNaN(amount) ? '0' : amount.toString()); 
    //console.log(sourceAmount);
    const calculatedAmount = isNaN(amount) ? 0 : amount * exchangeRate;
    console.log(exchangeRate);
    if (!isNaN(calculatedAmount)) {
      setTargetAmount(calculatedAmount);
    }
  };

  const handleTargetAmountChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const amount = parseFloat(event.target.value);
    setTargetAmount(isNaN(amount) ? 0 : amount);
    const calculatedAmount = isNaN(amount) ? 0 : amount / exchangeRate;
    if (!isNaN(calculatedAmount)) {
      setSourceAmount(calculatedAmount.toString());
    }
  };

  const handleCurrencyChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedCode = event.target.value;
    const selectedCurrency = currencies.find((currency) => currency.code === selectedCode);
    if (selectedCurrency) {
      setSourceCurrency(selectedCurrency);
    }
  };

  return (
    <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'flex-start', justifyContent: 'center', minHeight: '100vh' }}>
      <h2 style={{ margin: '0', marginBottom: '0.5rem', textAlign: 'left' }}>
        {parseFloat(sourceAmount).toFixed(3)} {sourceCurrency.name}
      </h2>
      <h2 style={{ margin: '0', textAlign: 'left' }}>
        {targetAmount.toFixed(3)} {targetCurrency.name}
      </h2>
      <div>
        <input
          type="number"
          value={sourceAmount}
          onChange={handleSourceAmountChange}
          style={{ fontSize: '1.2rem', padding: '0.5rem' }}
        />
        <select value={sourceCurrency.code} onChange={handleCurrencyChange} style={{ fontSize: '1.2rem', padding: '0.5rem' }}>
          {currencies.map((currency) => (
            <option key={currency.code} value={currency.code}>
              {currency.name}
            </option>
          ))}
        </select>
      </div>
      <div>
        <input
          type="number"
          value={targetAmount}
          onChange={handleTargetAmountChange}
          style={{ fontSize: '1.2rem', padding: '0.5rem' }}
        />
        <select value={targetCurrency.code} onChange={handleCurrencyChange} style={{ fontSize: '1.2rem', padding: '0.5rem' }}>
          {currencies.map((currency) => (
            <option key={currency.code} value={currency.code}>
              {currency.name}
            </option>
          ))}
        </select>
      </div>
      <button onClick={fetchExchangeRate}>Перевести или обновить</button>
    </div>
  );
};

export default CurrencyConverterForm;
