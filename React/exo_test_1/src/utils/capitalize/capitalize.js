export const capitalize = (str) => {
  if (/^[0-9]/.test(str)) {
    throw new Error('Cannot capitalize number');
  }
  return String(str).charAt(0).toUpperCase() + String(str).slice(1);
};
