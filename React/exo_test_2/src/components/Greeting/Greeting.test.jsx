import { render, screen } from '@testing-library/react';
import { describe, expect, it } from 'vitest';
import { Greeting } from './Greeting';

describe('Greeting', () => {
  it('Display text with props name', () => {
    render(<Greeting name="Rémi" />);
    expect(screen.getByText(/Rémi/i)).toBeInTheDocument();
  });
  it('Display "invité" if no name is given to the compponent', () => {
    render(<Greeting />);
    expect(screen.getByText(/invité/i)).toBeInTheDocument();
  });
});
