import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';

export const ExpenseSummary = () => {
  const bankData = useSelector((s) => s.bankData.value);
  const [total, setTotal] = useState(0);
  useEffect(() => {
    setTotal(
      bankData.reduce((acc, expense) => acc + Number(expense.amount), 0)
    );
  }, [bankData]);

  const categoryList = [
    'Alimentation',
    'Transport',
    'Loyer',
    'Loisirs',
    'Other',
  ];

  const expenses = categoryList.map((category, index) => {
    const totalExpenseByCategory = bankData
      .filter((expense) => expense.category == category)
      .reduce((acc, expense) => acc + Number(expense.amount), 0);

    return (
      <p key={index}>
        {category} : {totalExpenseByCategory}
      </p>
    );
  });

  return (
    <>
      <div
        style={{
          display: 'flex',
          gap: '24px',
        }}
      >
        <p>Total : {total}</p>
        {expenses}
      </div>
    </>
  );
};
