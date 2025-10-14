import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import { Searchbar } from './components/Searchbar.jsx';

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Searchbar />
  </StrictMode>
);
