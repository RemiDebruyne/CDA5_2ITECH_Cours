import { useCopyToClipboard } from '../hooks/useCoptyToClipboard';
import { useQuote } from '../hooks/useQuote';

export const QuoteDisplay = () => {
  const { quote, fetchNewQuote } = useQuote();
  const { copyToClipboard } = useCopyToClipboard();
  return (
    <>
      <h1>La citation du jour</h1>
      <blockquote>
        <p>{quote.quote}</p>
        <p>{`- ${quote.author}`}</p>
      </blockquote>

      <button onClick={fetchNewQuote}>Nouvelle citation</button>
      <button onClick={() => copyToClipboard(quote.quote)}>
        Copy to clipboard
      </button>
    </>
  );
};
