using System;
using System.Configuration;

namespace HangMan
{
    class Program
    {
        public delegate string ProcessString(string input);

        static void Main(string[] args)
        {
            bool isPlaying = false;
            string databasePath = ConfigurationManager.AppSettings["WordDatabase"];

            //WordReader wordManager = new WordReader(databasePath);
            InputManager inputManager = new InputManager();
            IScreenManager screenManager = new ScreenManager();
            GuessManager guessManager = new GuessManager();


            //string name = Console.ReadLine();
            isPlaying = true;
            screenManager.ShowScreen("tetetetet");

            while (isPlaying)
            {
                string playerInput = inputManager.ReadInput(Console.ReadLine());
                Console.WriteLine(guessManager.usedLetters);
                Console.WriteLine(guessManager.wordToGuess);
                if (!string.IsNullOrEmpty(playerInput))
                {
                    guessManager.VerifyGuess(playerInput);


                }



            }
            Console.WriteLine("-------------END---------------");
        }
    }
}