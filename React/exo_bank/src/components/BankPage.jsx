import { ExpenseForm } from './ExpenseForm';
import { ExpenseSummary } from './ExpenseSummary';
import { ExpenseDetail } from './ExpenseDetail';

export const Bankpage = () => {
  return (
    <>
      <h1>Suivi des dépenses V2</h1>
      <ExpenseSummary />
      <ExpenseForm />
      <ExpenseDetail />
    </>
  );
};
