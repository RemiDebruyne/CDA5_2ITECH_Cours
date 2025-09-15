import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import App from './App.jsx';
import { Question } from './components/Question.jsx';
import { Quizz } from './components/Quizz.jsx';

createRoot(document.getElementById('root')).render(
  <StrictMode>
    {/* <App /> */}
    <Quizz />
  </StrictMode>
);
