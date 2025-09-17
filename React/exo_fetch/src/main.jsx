import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import { QuoteDisplay } from './components/QuoteDisplay.jsx';

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <QuoteDisplay />
  </StrictMode>
);
