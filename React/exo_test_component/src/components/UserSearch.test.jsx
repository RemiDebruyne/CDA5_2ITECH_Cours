import { render, screen } from '@testing-library/react';
import { afterEach, describe, expect, vi, it } from 'vitest';
import { UserSearch } from './UserSearch';
import userEvent from '@testing-library/user-event';

describe('UserSearch', () => {
  afterEach(() => {
    vi.resetAllMocks();
  });

  it('Should display a searchInput and searchButton', async () => {
    render(<UserSearch />);

    expect(
      screen.getByRole('button', { name: /rechercher/i })
    ).toBeInTheDocument();

    expect(
      screen.getByPlaceholderText(/Saisissez un nom.../i)
    ).toBeInTheDocument();

    expect(screen.queryByText('chargement...')).not.toBeInTheDocument();

    expect(
      screen.queryByText(/Utilisateur introuvable/i)
    ).not.toBeInTheDocument();
  });

  it('Should display loading while fetching data', async () => {
    global.fetch = vi.fn().mockImplementation(
      () =>
        new Promise((resolve) => {
          setTimeout(() => {
            resolve({
              ok: true,
              json: () => Promise.resolve({ name: 'Jean' }),
            });
          }, 50);
        })
    );

    render(<UserSearch />);

    const searchInput = screen.getByPlaceholderText(/Saisissez un nom.../i);
    await userEvent.type(searchInput, 'Jean');

    const searchButton = screen.getByRole('button', { name: /Rechercher/i });

    await userEvent.click(searchButton);

    expect(screen.getByText(/Chargement.../i)).toBeInTheDocument();

    const username = await screen.findByTestId('username');

    expect(screen.queryByText(/Chargement.../i)).not.toBeInTheDocument();
  });

  it('Should display the user if query was sucessful', async () => {
    global.fetch = vi.fn().mockResolvedValue({
      ok: true,
      json: () => Promise.resolve({ name: 'Jean' }),
    });
    render(<UserSearch />);

    const searchInput = screen.getByPlaceholderText(/Saisissez un nom.../i);
    await userEvent.type(searchInput, 'Jean');

    const searchButton = screen.getByRole('button', { name: /Rechercher/i });

    await userEvent.click(searchButton);

    const username = await screen.findByTestId('username');

    expect(username).toHaveTextContent(/Jean/i);
  });

  it('Display an error if user was not found', async () => {
    global.fetch = vi.fn().mockImplementation(
      () =>
        new Promise((resolve) => {
          setTimeout(() => {
            resolve({
              ok: false,
              status: 404,
              json: () => Promise.resolve({ message: 'Not Found' }),
            });
          }, 50);
        })
    );

    render(<UserSearch />);

    const searchInput = screen.getByPlaceholderText(/Saisissez un nom.../i);
    await userEvent.type(searchInput, 'Jean');

    const searchButton = screen.getByRole('button', {
      name: /Rechercher/i,
    });

    await userEvent.click(searchButton);

    expect(screen.getByText(/chargement/i)).toBeInTheDocument();

    await screen.findByRole('alert');
    expect(screen.getByRole('alert')).toHaveTextContent(
      'Utilisateur introuvable'
    );
  });
});
