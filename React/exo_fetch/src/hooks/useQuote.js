import { useEffect, useState } from 'react';

export const useQuote = () => {
  const [quote, setQuote] = useState({});

  const fetchNewQuote = async () => {
    try {
      const response = await fetch('https://dummyjson.com/quotes/random');

      if (!response.ok) throw new Error(`HTTP ${response.status}`);

      setQuote(await response.json());
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchNewQuote();
  }, []);

  return { quote, fetchNewQuote };
};
