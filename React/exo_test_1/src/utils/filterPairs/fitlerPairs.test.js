import { describe, expect, it } from 'vitest';
import { filterPairs } from './filterPairs';

describe('getAverage', () => {
  it('return the average of all the value in the array', () => {
    expect(filterPairs(['a', 2, 3, 4])).toStrictEqual([2, 4]);
  });
});
