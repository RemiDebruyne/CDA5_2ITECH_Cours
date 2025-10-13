export const Greeting = ({ name = '' }) => {
  if (name === '') return <h1>Bonjour, invité</h1>;

  return <h1>Bonjour, {name}</h1>;
};
