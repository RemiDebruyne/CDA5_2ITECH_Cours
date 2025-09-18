import { NavLink, Route, Routes } from 'react-router-dom';
import { Bankpage } from '../../exo_bank/src/components/BankPage';
import { Gallery } from '../../exo_gallery/src/components/Gallery/Gallery';
import { QuoteDisplay } from '../../exo_fetch/src/components/QuoteDisplay';
import { Quizz } from '../../exo_question/src/components/Quizz/Quizz';
import './App.css';

function App() {
  return (
    <div>
      <nav
        style={{
          display: 'flex',
          gap: '24px',
        }}
      >
        <NavLink to="/bank">Exo Banque</NavLink>
        <NavLink to="/quote">Exo Fetch</NavLink>
        <NavLink to="/quizz">Exo Question</NavLink>
        <NavLink to="/gallery">Exo Gallery</NavLink>
      </nav>

      <Routes>
        <Route path="/bank" element={<Bankpage />} />
        <Route path="/quote" element={<QuoteDisplay />} />
        <Route path="/quizz" element={<Quizz />} />
        <Route path="/gallery" element={<Gallery />} />
      </Routes>
    </div>
  );
}

export default App;
