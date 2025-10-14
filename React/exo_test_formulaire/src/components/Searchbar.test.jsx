import { render, screen } from '@testing-library/react';
import { describe, expect, it, vi } from 'vitest';
import { Searchbar } from './Searchbar';
import userEvent from '@testing-library/user-event';

describe('Searchbar', () => {
  it('Click on button calls onSearch on the trimmed query', async () => {
    const handleSearch = vi.fn();
    render(<Searchbar onSearch={handleSearch} />);
    const searchInput = screen.getByPlaceholderText(/Rechercher.../i);
    await userEvent.type(searchInput, '             une recherche         ');

    const searchButton = screen.getByRole('button', { name: /Rechercher/i });
    await userEvent.click(searchButton);

    expect(handleSearch).toHaveBeenCalledTimes(1);
    expect(handleSearch).toHaveBeenCalledWith('une recherche');
  });

  it('Press enter calls onSearch on the trimmed query', async () => {
    const handleSearch = vi.fn();
    render(<Searchbar onSearch={handleSearch} />);
    const searchInput = screen.getByPlaceholderText(/Rechercher.../i);

    await userEvent.type(searchInput, '        une recherche{enter}       ');

    expect(handleSearch).toHaveBeenCalledTimes(1);
    expect(handleSearch).toHaveBeenCalledWith('une recherche');
  });

  it('search button should be disable if searchInput is empty', () => {
    const handleSearch = vi.fn();
    render(<Searchbar onSearch={handleSearch} />);

    const searchButton = screen.getByRole('button', { name: /Rechercher/i });
    expect(searchButton).toBeDisabled();
    expect(handleSearch).not.toHaveBeenCalled();
  });

  it('search button should be disable if searchInput is whitespaces', async () => {
    const handleSearch = vi.fn();
    render(<Searchbar onSearch={handleSearch} />);
    const searchInput = screen.getByPlaceholderText(/Rechercher.../i);
    await userEvent.type(searchInput, '              ');

    const searchButton = screen.getByRole('button', { name: /Rechercher/i });
    expect(searchButton).toBeDisabled();
    expect(handleSearch).not.toHaveBeenCalled();
  });

  it('Press enter shoudl not call onSearch if trimmed query is empty', async () => {
    const handleSearch = vi.fn();
    render(<Searchbar onSearch={handleSearch} />);
    const searchInput = screen.getByPlaceholderText(/Rechercher.../i);
    await userEvent.type(searchInput, '                   {enter}');

    expect(handleSearch).not.toHaveBeenCalled();
  });

  it('Expect searchInput then searchButton to be focus after first and second tabulation', async () => {
    const handleSearch = vi.fn();
    render(<Searchbar onSearch={handleSearch} />);
    // const searchInput = screen.getByPlaceholderText(/Rechercher.../i);
    const searchInput = screen.getByRole('textbox', { name: /search/i });
    await userEvent.tab();
    expect(searchInput).toHaveFocus();

    const searchButton = screen.getByRole('button', { name: /Rechercher/i });
    await userEvent.tab();
    expect(searchButton).toHaveFocus();
  });
});
