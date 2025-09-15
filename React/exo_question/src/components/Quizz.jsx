import { QUESTIONS } from '../assets/quiz';
import { Question } from './Question';
import { useState } from 'react';

export const Quizz = () => {
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [score, setScore] = useState(0);
  const currentQuestion = QUESTIONS[currentQuestionIndex];

  const handleAnswerClick = (_, answer) => {
    const currentAnswer = currentQuestion.choices.find(
      (choice) => choice.id == currentQuestion.answerId
    ).label;

    if (currentAnswer == answer) {
      setScore(score + 1);
    }

    setCurrentQuestionIndex((currentQuestionIndex) => currentQuestionIndex + 1);
  };

  if (currentQuestionIndex < QUESTIONS.length) {
    return (
      <>
        <h1>Le grand quizz</h1>
        <Question
          question={currentQuestion}
          onAnswerClick={handleAnswerClick}
        />
      </>
    );
  } else {
    return (
      <h2>
        Votre score est : {score} / {QUESTIONS.length}
      </h2>
    );
  }

  // Autre version avec un seul return qui à un résultat différent conditionnellement.
  // La différence est uniquement syntaxique
  //   return (
  //     <>
  //       {currentQuestionIndex < QUESTIONS.length ? (
  //         <>
  //           <h1>Le grand quizz</h1>
  //           <Question
  //             question={currentQuestion}
  //             onAnswerClick={handleAnswerClick}
  //           />
  //         </>
  //       ) : (
  //         <h2>
  //           Votre score est : {score} / {QUESTIONS.length}
  //         </h2>
  //       )}
  //     </>
  //   );
};
