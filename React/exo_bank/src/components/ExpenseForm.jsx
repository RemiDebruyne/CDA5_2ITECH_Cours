import { useRef, useState } from 'react';
import { useDispatch } from 'react-redux';
import { addExpense } from '../store';

export const ExpenseForm = () => {
  //   const form = useRef({
  //     description: '',
  //     amount: 0.0,
  //     category: '',
  //     date: '',
  //   });

  // const id = useSt(Crypto.randomUUID());
  const [id, setId] = useState(crypto.randomUUID());
  const description = useRef('');
  const amount = useRef(0.0);
  const category = useRef('');
  const date = useRef('');

  const dispatch = useDispatch();

  const categoryList = [
    'Alimentation',
    'Transport',
    'Loyer',
    'Loisirs',
    'Other',
  ];

  const submitForm = (e) => {
    e.preventDefault();
    setId(crypto.randomUUID());
    dispatch(
      addExpense({
        id: id,
        description: description.current.value,
        amount: Number(amount.current.value),
        category: category.current.value,
        date: date.current.value,
      })
    );
  };

  // Fonction onChange nécessaire seulement avec useState, pas useRef
  //   const handleFormChange = (e) => {
  //     const { name, value } = e.target;

  //     form.current[name] = value;
  //   };

  return (
    <form onSubmit={submitForm}>
      <input type="hidden" value={id} />
      <label>
        Libellé
        {/* Pour référencer un useRef qui est un objet il faut faire
         ref={(el) => (inputRefs.current['amount'] = el)}
        */}
        <input ref={description} type="text" name="description"></input>
      </label>
      <label>
        Montant
        <input ref={amount} type="text" name="amount"></input>
      </label>
      <label>
        Catégorie
        <select ref={category} name="category">
          {categoryList.map((category) => (
            <option key={category} value={category}>
              {category}
            </option>
          ))}
        </select>
      </label>
      <label>
        Date
        <input
          ref={date}
          //   defaultValue={Date.now()}
          type="date"
          name="date"
        ></input>
      </label>
      <button>Ajouter</button>
    </form>
  );
};
