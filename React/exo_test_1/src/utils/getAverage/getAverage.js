export const getAverage = (arr) => {
  if (arr.length === 0) {
    throw new Error('Array cannot be empty');
  }

  if (arr.length === 1) {
    return arr[0];
  }

  let sum = 0;
  for (let i = 0; i < arr.length; i++) {
    sum += arr[i];
  }

  return sum / arr.length;
};
