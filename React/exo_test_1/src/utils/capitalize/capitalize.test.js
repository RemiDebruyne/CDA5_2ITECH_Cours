import { describe, expect, it } from 'vitest';
import { capitalize } from './capitalize';

describe('capitalize()', () => {
  it('Capitalize the first letter of a word', () => {
    expect(capitalize('bonjour')).toBe('Bonjour');
  });

  it('Capitalize first letter even if another letter is capitalized', () => {
    expect(capitalize('rEact')).toBe('REact');
  });
  it('Error if string includes number', () => {
    expect(() => capitalize('123')).toThrow('Cannot capitalize number');
  });
});
