using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Diagnostics.CodeAnalysis;

namespace HangmaneGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

      
            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("---------------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { 
                "blob", 
                "fish",
                "soup",
                "hollow",
                "lion",
                "tower",
                "skin",
                "sword",
                "dog",
                "world", 
                "jazz",
                "quiz",
                "fox",
                "horse",
                "face",};

            int index = random.Next(wordDictionary.Count);
            string randomWord = wordDictionary[index];

            int cursorLeft = 2;
            int cursorTop = 4;

            Console.SetCursorPosition(cursorLeft, cursorTop);
            
            foreach (char x in randomWord)

            {
                Console.Write(" _ ");
            }

            Console.WriteLine();

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            string lettersCorrectSoFar = ""; 

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.WriteLine("\nLetters guessed so far:  " + string.Join(" ", currentLettersGuessed));
                Console.WriteLine("Letters guessed correctly so far: " + lettersCorrectSoFar);
                Console.WriteLine("Guess a letter:  ");
                char letterGuessed = Console.ReadLine()[0];
                Console.Clear();
               

                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.WriteLine("\r\nYou have already guessed this letter ");
                    PrintHangman(amountOfTimesWrong);
                    currentLettersRight =PrintWord(currentLettersGuessed, randomWord);
                   // PrintLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterGuessed == randomWord[i])
                        {
                            right = true;
                            lettersCorrectSoFar += letterGuessed + " at position " + (i + 1) + ", ";
                        }
                    }

                    if (right)
                    {
                        PrintHangman(amountOfTimesWrong);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = PrintWord(currentLettersGuessed, randomWord);
                        Console.WriteLine("\r\n");
                       // PrintLines(randomWord);
                    }
                    else
                    {
                        amountOfTimesWrong++;
                        currentLettersGuessed.Add(letterGuessed);
                        PrintHangman(amountOfTimesWrong);
                        currentLettersRight = PrintWord(currentLettersGuessed, randomWord);
                        Console.WriteLine("\r\n");
                       // PrintLines(randomWord);
                    }
                    
                }
                

            }
            if (currentLettersRight == randomWord.Length)
            {
                Console.WriteLine("\r\nCongratualtions you gussed the correct word:"  + randomWord);
            }
            else 
            {
                Console.WriteLine("\r\nGame over. The secret word was: " + randomWord);
            }

        }

        private static void PrintHangman(int wrong)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine();
            Console.WriteLine(" I---");
            Console.WriteLine(" I  O");

            switch (wrong)
            {
                case 1:
                    Console.WriteLine(" I   ");
                    Console.WriteLine(" I   ");
                    Console.WriteLine(" ===== ");
                    break;
                case 2:
                    Console.WriteLine(" I  | ");
                    Console.WriteLine(" I   ");
                    Console.WriteLine(" ===== ");
                    break;
                case 3:
                    Console.WriteLine(" I  |\\");
                    Console.WriteLine(" I    ");
                    Console.WriteLine(" ===== ");
                    break;
                case 4:
                    Console.WriteLine(" I /|\\");
                    Console.WriteLine(" I   ");
                    Console.WriteLine(" ===== ");
                    break;
                case 5:
                    Console.WriteLine(" I /|\\");
                    Console.WriteLine(" I /  ");
                    Console.WriteLine(" ===== ");
                    break;
                case 6:
                    Console.WriteLine(" I /|\\");
                    Console.WriteLine(" I / \\");
                    Console.WriteLine(" ===== ");
                    break;
                default:
                    Console.WriteLine(" I   ");
                    Console.WriteLine(" I   ");
                    Console.WriteLine(" ===== ");
                    break;

            }
        }


            
        private static int PrintWord(List<char> guessedLetters, string randomWord)
        {
            int count = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.Write("_ ");
                }
                count++;
            }
            return rightLetters;
        }


        //private static void PrintLines(string randomWord)
        //{
         //   Console.Write("\r");
         //   foreach (char c in randomWord)
         //   {
           //     Console.OutputEncoding = System.Text.Encoding.Unicode;
           //     Console.Write(" - ");
           // }
        }

    } 

