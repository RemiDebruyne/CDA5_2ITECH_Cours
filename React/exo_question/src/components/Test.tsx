import React, { useState } from 'react';

const objets = [
  { id: 1, nom: 'Objet 1', description: 'Description de l’objet 1' },
  { id: 2, nom: 'Objet 2', description: 'Description de l’objet 2' },
  { id: 3, nom: 'Objet 3', description: 'Description de l’objet 3' },
];

export const Test = () => {
  const [indexCourant, setIndexCourant] = useState(0);

  const allerAuSuivant = () => {
    setIndexCourant((prevIndex) => prevIndex + 1);
  };

  const objetActuel = objets[indexCourant];

  return (
    <div style={{ padding: '20px' }}>
      {indexCourant < objets.length ? (
        <div>
          <h2>{objetActuel.nom}</h2>
          <p>{objetActuel.description}</p>
          <button onClick={allerAuSuivant}>Suivant</button>
        </div>
      ) : (
        <h2>C’est terminé !</h2>
      )}
    </div>
  );
};
