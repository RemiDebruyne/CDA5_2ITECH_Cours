import { findByText, render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import { CartProvider } from '../context/CartContext';
import { ShoppingList } from './ShoppingList';
import { expect, it } from 'vitest';

function renderWithProvider(ui) {
  return render(<CartProvider>{ui}</CartProvider>);
}

describe('ShoppingList (integration parent/enfant + contexte)', () => {
  it('état initial et accessibilité', () => {
    renderWithProvider(<ShoppingList />);
    expect(screen.getByText(/Total : 0/)).toBeInTheDocument();
    expect(screen.getByText(/Aucun article/)).toBeInTheDocument();
  });

  it("ajout d'un article met a jour la liste et le total", async () => {
    renderWithProvider(<ShoppingList />);
    const addButton = screen.getByRole('button', { name: /Ajouter/i });
    const input = screen.getByPlaceholderText(/Nouvel article/i);

    await userEvent.type(input, 'Lait');
    await userEvent.click(addButton);

    expect(input).toHaveTextContent('');
    expect(screen.getByText(/Lait/i)).toBeInTheDocument();
    expect(screen.getByText(/Total : 1/i)).toBeInTheDocument();
  });

  it('ajouts multiples', async () => {
    renderWithProvider(<ShoppingList />);
    const addButton = screen.getByRole('button', { name: /Ajouter/i });
    const input = screen.getByPlaceholderText(/Nouvel article/i);

    await userEvent.type(input, 'Lait');
    await userEvent.click(addButton);

    await userEvent.type(input, 'Pain');
    await userEvent.click(addButton);

    expect(screen.getByText(/Total : 2/i)).toBeInTheDocument();
  });

  it('ajouts multiples et toggle achete', async () => {
    renderWithProvider(<ShoppingList />);

    const addButton = screen.getByRole('button', { name: /Ajouter/i });
    const input = screen.getByPlaceholderText(/Nouvel article/i);

    await userEvent.type(input, 'Lait');
    await userEvent.click(addButton);
    const boughtButton = screen.getByLabelText(/Marquer Lait comme acheté/i);
    await userEvent.click(boughtButton);

    expect(screen.getByText(/Lait \[acheté\]/i)).toBeInTheDocument();
  });

  it("suppression d'un article", async () => {
    renderWithProvider(<ShoppingList />);

    const addButton = screen.getByRole('button', { name: /Ajouter/i });
    const input = screen.getByPlaceholderText(/Nouvel article/i);

    await userEvent.type(input, 'Lait');
    await userEvent.click(addButton);

    expect(screen.getByText(/Total : 1/i)).toBeInTheDocument();

    const deleteButton = screen.getByRole('button', { name: /Supprimer/i });

    await userEvent.click(deleteButton);

    expect(screen.getByText(/Total : 0/i)).toBeInTheDocument();
    expect(screen.queryByText(/Lait/i)).not.toBeInTheDocument();
  });
});
