import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import { Quizz } from './components/Quizz/Quizz';
import { Gallery } from './components/Gallery/Gallery';

createRoot(document.getElementById('root')).render(
  <StrictMode>
    {/* <App /> */}
    {/* <Quizz /> */}
    <Gallery />
  </StrictMode>
);
