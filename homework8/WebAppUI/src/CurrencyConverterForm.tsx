import React, { useState, useEffect } from 'react';
import axios from 'axios';

// Интерфейс для валюты
interface Currency {
  code: string;
  name: string;
}

// Интерфейс для пропсов компонента
interface CurrencyConverterFormProps {
  currencies: Currency[];
}

// Создаем компонент CurrencyConverterForm, принимающий пропс currencies типа CurrencyConverterFormProps.
const CurrencyConverterForm: React.FC<CurrencyConverterFormProps> = ({ currencies }) => {

  // Состояние компонента:
  const [sourceAmount, setSourceAmount] = useState<string>('0'); // Состояние для значения исходной суммы в виде строки.
  const [targetAmount, setTargetAmount] = useState<number>(0);  // Состояние для значения целевой суммы в виде числа.
  const [sourceCurrency, setSourceCurrency] = useState<Currency>(currencies[0]); // Состояние для выбранной исходной валюты.
  const [targetCurrency, setTargetCurrency] = useState<Currency>(currencies[1]); // Состояние для выбранной целевой валюты.
  const [showDescription, setShowDescription] = useState<boolean>(false); // Состояние для отображения описания (не используется в данном коде).
  const [exchangeRate, setExchangeRate] = useState<number>(0.011); // Состояние для значения обменного курса.

  // Функция для обновления курса валют с сервера
  const fetchExchangeRate = () => {
    axios
      .get(
        `http://localhost:5000/prices?PaymentCurrency=${sourceCurrency.code}&PurchasedCurrency=${targetCurrency.code}`
      )
      .then((response) => {
        const exchangeRate = response.data.Price;
        setExchangeRate(exchangeRate); // Обновляем состояние exchangeRate с новым значением курса.
        const calculatedAmount = isNaN(parseFloat(sourceAmount)) ? 0 : parseFloat(sourceAmount) * exchangeRate;
        // Вычисляем новое значение для целевой суммы на основе исходной суммы и обменного курса.
        if (!isNaN(calculatedAmount)) {
          setTargetAmount(calculatedAmount); // Обновляем состояние targetAmount с новой рассчитанной суммой.
        }
      })
      .catch((error) => {
        console.error('Ошибка при получении данных с сервера:', error); // Обрабатываем ошибки при получении данных с сервера.
      });
  };

  // Загружаем курс валют с сервера и устанавливаем интервал обновления
  useEffect(() => {
    fetchExchangeRate(); // Загружаем курс валют с сервера при монтировании компонента.

    // Устанавливаем интервал обновления данных каждые 10 секунд
    const interval = setInterval(fetchExchangeRate, 10000);
    // Устанавливаем интервал для периодического обновления курса каждые 10 секунд.

    // Очистить интервал при размонтировании компонента
    return () => clearInterval(interval); // Очищаем интервал при размонтировании компонента.
  }, [sourceCurrency, targetCurrency]); // Мониторим изменения исходной и целевой валюты, чтобы обновить курс при их изменении.

  // Обработчик изменения значения исходной суммы
  const handleSourceAmountChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const amount = parseFloat(event.target.value);
    setSourceAmount(isNaN(amount) ? '0' : amount.toString()); // Обновляем состояние sourceAmount с новым значением исходной суммы.

    const calculatedAmount = isNaN(amount) ? 0 : amount * exchangeRate;
    // Вычисляем новое значение для целевой суммы на основе новой исходной суммы и обменного курса.
    if (!isNaN(calculatedAmount)) {
      setTargetAmount(calculatedAmount); // Обновляем состояние targetAmount с новой рассчитанной суммой.
    }
  };

  // Обработчик изменения значения целевой суммы
  const handleTargetAmountChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const amount = parseFloat(event.target.value);
    setTargetAmount(isNaN(amount) ? 0 : amount); // Обновляем состояние targetAmount с новым значением целевой суммы.

    const calculatedAmount = isNaN(amount) ? 0 : amount / exchangeRate;
    // Вычисляем новое значение для исходной суммы на основе новой целевой суммы и обменного курса.
    if (!isNaN(calculatedAmount)) {
      setSourceAmount(calculatedAmount.toString()); // Обновляем состояние sourceAmount с новой рассчитанной суммой.
    }
  };

  // Обработчик изменения выбранной валюты
  const handleCurrencyChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedCode = event.target.value;
    const selectedCurrency = currencies.find((currency) => currency.code === selectedCode);
    // Находим объект выбранной валюты по коду валюты из выпадающего списка.
    if (selectedCurrency) {
      setSourceCurrency(selectedCurrency); // Обновляем состояние sourceCurrency с новым значением выбранной валюты.
    }
  };

  // Обработчик клика на кнопку "Перевести"
  const handleConvertClick = () => {
    const calculatedAmount = parseFloat(sourceAmount) * exchangeRate;
    // Вычисляем новое значение для целевой суммы на основе исходной суммы и обменного курса.
    if (!isNaN(calculatedAmount)) {
      setTargetAmount(calculatedAmount); // Обновляем состояние targetAmount с новой рассчитанной суммой.
    }
  };

  // Возвращаем JSX разметку компонента
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
      <button onClick={handleConvertClick}>Перевести</button>
      <button onClick={fetchExchangeRate}>Обновить</button>
    </div>
  );
};

export default CurrencyConverterForm;
