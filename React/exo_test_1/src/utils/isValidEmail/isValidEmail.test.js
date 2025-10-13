import { describe, expect, it } from 'vitest';
import { isValidEmail } from './isValidEmail';

describe('getAverage', () => {
  it('string should be an email', () => {
    expect(isValidEmail('test@mail.com')).toBe(true);
  });
});
