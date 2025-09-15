export const Question = ({ question, onAnswerClick }) => {
  const choices = question.choices.map((choice) => {
    return (
      <button key={choice.id} onClick={(e) => onAnswerClick(e, choice.label)}>
        {choice.label}
      </button>
    );
  });

  return (
    <>
      <h1>{question.prompt}</h1>
      <ul
        style={{
          display: 'flex',
          flexDirection: 'column',
          gap: '10px',
        }}
      >
        {choices}
      </ul>
    </>
  );
};
