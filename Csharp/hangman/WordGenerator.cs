using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman;

public static class WordGenerator
{
    public static List<string> Words = ["banane", "maison", "balle", "pantoufle"];

    public static string GenerateWord()
    {
        var random = new Random();
        return Words[random.Next(0, 4)];
    }

}
