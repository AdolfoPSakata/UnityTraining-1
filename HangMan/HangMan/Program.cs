using System;
using System.Configuration;

namespace UnityTraining_1
{
    class Program
    {
        public delegate string ProcessString(string input);

        static void Main(string[] args)
        {
            bool isPlaying = false;
            string databasePath = ConfigurationManager.AppSettings["WordDatabase"];

            WordManager wordManager = new WordManager(databasePath);
            InputManager inputManager = new InputManager();
            ScreenManager screenManager = new ScreenManager();
            GuessManager guessManager = new GuessManager();
            //string name = Console.ReadLine();
            //screenManager.ShowScreen();
            isPlaying = true;
            screenManager.ShowScreen();
            Console.ReadLine();
            //while (true)
            //{
                
            //    //string input = Console.ReadLine();
            //    //handler
            //    //arrumar
            //    //Console.WriteLine(inputManager.ReadInput(input));

            //}
            //while (isPlaying)
            //{
            //    string currentWord = wordManager.GetRandomWord();
            //    Console.WriteLine(name + "/n ------------working----------------- " + currentWord );

            //}
        }
    }
}