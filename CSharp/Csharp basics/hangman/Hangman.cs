using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace hangman;

public class Hangman
{
    public string GuessWord { get; set; }
    public string Mask { get; set; }
    public bool IsOver { get; set; }
    public int Life { get; set; } = 10;

    public bool IsLose { get; set; } = false;
    public bool IsWin { get; set; } = false ;


    public Hangman()
    {
        GuessWord = WordGenerator.GenerateWord();
        var strBuilder = new StringBuilder();
        foreach (var c in GuessWord)
        {
            strBuilder.Append("*");
        }

        Mask = strBuilder.ToString();
    }

    public void CheckChar(string character)
    {
        if (GuessWord.Contains(character))
        {
            ReplaceMask(character);
        } else
        {
            Life--;
        }
    }


    public bool CheckWin()
    {
        return Mask == GuessWord;
    }

    public bool CheckLose()
    {
        return Life == 0;
    }

    public void DisplayWord()
    {
        Console.WriteLine($"The word to find is : {string.Join("", Mask)}");
    }

    public void ReplaceMask(string characterFromUser)
    {
        var newMask = "";
        foreach(char letter in GuessWord)
        {
            if (Mask[GuessWord.IndexOf(letter)] != '*')
            {
                newMask += letter;
            }

            else if(letter.ToString() == characterFromUser)
            {
                newMask += characterFromUser;
            }
            else
            {
                newMask += "*";
            }
        }

        Mask = newMask;
    }
}
