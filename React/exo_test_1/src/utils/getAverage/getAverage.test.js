import { describe, expect, it } from 'vitest';
import { getAverage } from './getAverage';

describe('getAverage', () => {
  it('return the average of all the value in the array', () => {
    expect(getAverage([0, 10])).toBe(5);
  });

  it('return the only value in the array if it only has one', () => {
    expect(getAverage([10])).toBe(10);
  });
  it('return an exception if array is empty', () => {
    expect(() => getAverage([])).toThrow('Array cannot be empty');
  });
});
