using System;
using System.Threading;
using System.Threading.Tasks;
using StringBuffer;

namespace HangMan
{
    class Program
    {
        //public delegate string ProcessString(string input);

        static void Main(string[] args)
        {
            bool isPlaying = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            IScreenManager screenManager = new ScreenManager();
            InputManager inputManager = new InputManager();
            GuessManager guessManager = new GuessManager();

            screenManager.ShowScreen(ScreensTypes.ScreenType.Splash);
            Thread.Sleep(3000);
            screenManager.ShowScreen(ScreensTypes.ScreenType.Menu);
            Console.ReadLine();
            screenManager.ShowScreen(ScreensTypes.ScreenType.Intro);
            Console.ReadLine();
            screenManager.ShowScreen(ScreensTypes.ScreenType.Pact);
            string playerName = Console.ReadLine();
            screenManager.ChangeDictionaryText(Screens.ScreenNames.Name, playerName);
            screenManager.SendBufferChanges(Screens.ScreenNames.Name);

            string rightLetters = guessManager.GetRightLetters();
            screenManager.ChangeDictionaryText(Screens.ScreenNames.GuessWord, rightLetters);
            
            //create game
            isPlaying = true;
            //TODO: Fix tahat

            while (isPlaying)
            {
            screenManager.ShowScreen(ScreensTypes.ScreenType.Game);
                string playerInput = inputManager.ReadInput(Console.ReadLine());

                if (!string.IsNullOrEmpty(playerInput))
                {
                    rightLetters = guessManager.VerifyGuess(playerInput);
                    string usedLetters = guessManager.GetUsedLetters();
                    screenManager.ChangeDictionaryText(Screens.ScreenNames.GuessWord, rightLetters);
                    screenManager.ChangeDictionaryText(Screens.ScreenNames.UsedLetters, usedLetters);

                    if (rightLetters == "WIN")
                    {
                        screenManager.ShowScreen(ScreensTypes.ScreenType.Win);
                        Task.Delay(5000);
                        break;
                        //screenManager.ChangeDictionaryText(Screens.ScreenNames.Message, rightLetters);
                    }
                    else if (rightLetters == "DEAD")
                    {
                        screenManager.ShowScreen(ScreensTypes.ScreenType.Lose);
                        Task.Delay(5000);
                        break;
                        //screenManager.ChangeDictionaryText(Screens.ScreenNames.Message, rightLetters);
                    }
                    screenManager.ShowScreen(ScreensTypes.ScreenType.Game);
                }
            }
            Console.ReadLine();
        }
    }
}