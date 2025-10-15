import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import { ShoppingList } from './components/ShoppingList';
import { CartProvider } from './context/CartContext';

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <CartProvider>
      <ShoppingList />
    </CartProvider>
  </StrictMode>
);
