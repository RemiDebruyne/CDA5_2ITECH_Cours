export const isValidEmail = (str) => {
  return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(str);
};
