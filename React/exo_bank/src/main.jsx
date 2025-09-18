import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import { Bankpage } from './components/BankPage';
import { Provider } from 'react-redux';
import { store } from './store';

createRoot(document.getElementById('root')).render(
  <Provider store={store}>
    <Bankpage />
  </Provider>
);
