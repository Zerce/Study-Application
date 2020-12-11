using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;


namespace Data_Study_Applucation_1._2
{
    class Vocab
    {
        public static string DataFile = "terms.txt";
        public static string Content = "(Empty File)";

        public static string TermNames = "termNames.txt";
        public static string TermDescriptions = "termDescriptions.txt";

        public static List<string> TNames = new List<string>();
        public static List<string> TDefs = new List<string>();

        public static void DisplayTerms()
        {
            if (File.Exists(DataFile))
            {
                Content = File.ReadAllText(DataFile);
            }
            WriteLine(Content);
        }

        public static void UpdateTerms()
        {
            if (File.Exists(TermNames))
            {
                using (StreamReader sr = File.OpenText(TermNames))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        TNames.Add(s);
                    }
                }
            }
            if (File.Exists(TermDescriptions))
            {
                using (StreamReader sr = File.OpenText(TermDescriptions))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        TDefs.Add(s);
                    }
                }
            }
        }
        public static void Play()
        {
            for (int i = 1; i <= TNames.Count; i++)
            {
                Clear();
                ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("Question " + i + " out of " + TNames.Count);
                ResetColor();
                Question();

            }
            Game.End();
        }
        public static void Question()
        {
            Random RandomNumber = new Random();
            int RandomIndex;
            RandomIndex = RandomNumber.Next(15);
            ;

            WriteLine("\nMatch the term to its definition:\n");
            BackgroundColor = ConsoleColor.DarkGray;
            ForegroundColor = ConsoleColor.White;
            WriteLine(TDefs[RandomIndex]);
            ResetColor();

            ForegroundColor = ConsoleColor.Cyan;
            Player.Answer = Console.ReadLine();
            ResetColor();
            WriteLine("You answered: " + Player.Answer + " | The real answer: " + TNames[RandomIndex]);
            Player.Answer = Player.Answer.ToLower();

            if (Player.Answer == TNames[RandomIndex])
            {
                Game.CorrectAnswers++;
                WriteLine("You gained a point!");
            }
            else
            {
                WriteLine("You didn't gain a point.");
            }
            WriteLine("Press enter to move on to the next question.");

            ReadKey();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}