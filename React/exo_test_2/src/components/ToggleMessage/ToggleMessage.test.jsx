import { render, screen } from '@testing-library/react';
import { describe, expect, it } from 'vitest';
import { ToggleMessage } from './ToggleMessage';
import userEvent from '@testing-library/user-event';

describe('ToggleMessage', () => {
  it('Message should not be displayed on first render', () => {
    render(<ToggleMessage />);
    expect(screen.queryByText(/Text/i)).toBeNull();
  });

  it('Displays message after one click on the button', async () => {
    render(<ToggleMessage />);

    const user = userEvent.setup();
    const displayButton = screen.getByRole('button', { name: /display/i });

    await user.click(displayButton);
    expect(screen.getByText(/Text/i)).toBeInTheDocument();
  });

  it('Hide message after two click on the button', async () => {
    render(<ToggleMessage />);

    const user = userEvent.setup();
    const button = screen.getByRole('button', { name: /display/i });
    // const hideButton = screen.getByRole('button', { name: /hide/i });

    await user.click(button);
    !expect(screen.getByText(/Text/i)).toBeInTheDocument();
  });
});
