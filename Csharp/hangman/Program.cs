using hangman;


Console.WriteLine("================ Welcome the the Hangman game ================ \n");

PlayHangman();

void PlayHangman()
{
    var hangman = new Hangman();

    Console.WriteLine("Combien vouez-vous d'essai ? (défaut : 10)");
    int userInput = 0;

    var isInputValid = int.TryParse(Console.ReadLine(), out userInput);

    if (isInputValid)
        hangman.Life = userInput;

    while (!hangman.IsOver)
    {



        hangman.DisplayWord();
        Console.WriteLine($"You have {hangman.Life} attemps left");
        hangman.CheckChar(Console.ReadLine());
        if (hangman.CheckWin())
        {
            hangman.IsWin = true;
            hangman.IsOver = true;
        }

        if (hangman.CheckLose())
        {
            Console.WriteLine("You have no attemps left");
            Console.WriteLine($"The answer was : {hangman.GuessWord}");
            hangman.IsOver = true;
        }
    }

    if(hangman.IsWin)
        Console.WriteLine("Congratulations, you won");

    Console.WriteLine("Would you like to play again y/n ?");
    var playAgain = Console.ReadLine();

    if (playAgain == "y")
        PlayHangman();
}