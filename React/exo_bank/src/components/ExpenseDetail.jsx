import { useSelector, useDispatch } from 'react-redux';
import { removeExpense } from '../store';

export const ExpenseDetail = () => {
  const dispatch = useDispatch();

  const bankData = useSelector((s) => s.bankData.value);
  const expenseDetails = bankData.map((expense, index) => {
    return (
      <div
        key={index}
        style={{
          display: 'flex',
          justifyContent: 'space-between',
        }}
      >
        <div>
          <p>{expense.description}</p>
          <div>
            <p>
              {expense.category} {expense.date}
            </p>
          </div>
        </div>
        <div>
          <p>{expense.amount}</p>
          <button
            onClick={() =>
              dispatch(
                removeExpense({
                  id: expense.id,
                  description: expense.description,
                  amount: expense.amount,
                  category: expense.category,
                  date: expense.date,
                })
              )
            }
          >
            Supprimer
          </button>
        </div>
      </div>
    );
  });

  return (
    <div
      style={{
        display: 'flex',
        flexDirection: 'column',
        gap: '12px',
      }}
    >
      {expenseDetails}
    </div>
  );
};
