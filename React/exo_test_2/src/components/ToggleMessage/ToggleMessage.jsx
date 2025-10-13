export const ToggleMessage = () => {
  let isHidden = true;

  return (
    <>
      <button>{isHidden ? 'display' : 'hide'}</button>
      <h1
        style={{
          visibility: isHidden ? 'hidden' : 'visible',
        }}
      >
        Text
      </h1>
    </>
  );
};
