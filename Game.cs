using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Xml;
using System.ComponentModel;

namespace Data_Study_Applucation_1._2
{
    class Game
    {
        public static int CorrectAnswers = 0;

        public static void Start()
        {
            Welcome();
        }
        public static void Welcome()
        {
            Title = "Study Applications by Rigoberto Cervantes";
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Welcome!");
            ResetColor();
            WriteLine("\nHello Human! Enter your name to begin.");
            ForegroundColor = ConsoleColor.Cyan;
            Player.Name = ReadLine();
            Player.Name = Player.Name.ToUpper();
            ResetColor();
            WriteLine("\nWhat's up " + Player.Name + ", welcome to my Study Game!");
            GetOption();

        }
        public static void GetOption()
        {
            string Input;

            WriteLine("Would you like to see what terms you will be tested on?\nOr would you like to just jump right in it?\nPress \"A\" to review the terms or \"B\" to continue into the game...");
            ForegroundColor = ConsoleColor.Cyan;
            Input = ReadLine();
            Input = Input.ToUpper();
            ResetColor();
            switch (Input)
            {
                case "A":
                    Clear();
                    WriteLine("Here are the terms and definitions to review: \n\n");
                    BackgroundColor = ConsoleColor.DarkGray;
                    ForegroundColor = ConsoleColor.White;
                    Vocab.DisplayTerms();
                    Vocab.UpdateTerms();
                    ResetColor();
                    WriteLine("\n\nWhenever you're ready to begin reviewing, press \"A\"");
                    ForegroundColor = ConsoleColor.Cyan;
                    Input = ReadLine();
                    Input = Input.ToUpper();
                    ResetColor();
                    if (Input == "A")
                    {
                        Vocab.Play();
                    }
                    break;
                case "B":
                    Vocab.Play();
                    break;
                default:
                    WriteLine("I'm sorry that wasn't an option.");
                    GetOption();
                    break;
            }
        }
        public static void End()
        {
            string input = "S";

            Clear();
            WriteLine("You had a total of " + CorrectAnswers + "/ 15 correct answers. I'm Impress Human!");
            WriteLine("If you would like to play again, type \"play\". If not, type \"bye\".");
            ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine();
            input = input.ToUpper();
            ResetColor();
            if (input == "PLAY")
            {
                Reset();
                Start();
            }
            else if (input == "BYE")
            {
                System.Environment.Exit(0);
            }
        }

        public static void Reset()
        {
            Clear();
            CorrectAnswers = 0;
        }
    }
}

