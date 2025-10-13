import { render, screen } from '@testing-library/react';
import { describe, expect, it, vi } from 'vitest';
import { ButtonCallback } from './ButtonCallback';
import userEvent from '@testing-library/user-event';

describe('Counter', () => {
  it('onClick props get called when button is clicked', async () => {
    const onClickCallback = vi.fn();

    render(<ButtonCallback onClick={onClickCallback} />);

    const user = userEvent.setup();
    await user.click(screen.getByRole('button', { name: /button/i }));

    expect(onClickCallback).toHaveBeenCalledTimes(1);
  });
});
