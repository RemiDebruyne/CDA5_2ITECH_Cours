import { useState } from 'react';

export const ToggleMessage = () => {
  const [isHidden, setIsHidden] = useState(true);

  return (
    <>
      <button onClick={() => setIsHidden(!isHidden)}>
        {isHidden ? 'display' : 'hide'}
      </button>
      {!isHidden && <h1>Text</h1>}
    </>
  );
};
