using StringBuffer;
using System;
using System.Threading;

namespace HangMan
{
    class Program
    {
        //public delegate string ProcessString(string input);

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IScreenManager screenManager = new ScreenManager();
            
            ScreenInput screenInput = new ScreenInput();

            screenManager.ShowScreen(ScreensTypes.ScreenType.Splash);
            Thread.Sleep(3000);
            StartGame(screenManager, screenInput);
        }
        static void StartGame(IScreenManager screenManager, ScreenInput screenInput)
        {
            ScreensTypes.ScreenType currentScreen = ScreensTypes.ScreenType.Menu;
            screenManager.ShowScreen(currentScreen);

            while (true)
            {
                Action action = screenInput.GetInputOption(Console.ReadLine(), currentScreen);
                if (action != null)
                {
                    action.Invoke();
                    currentScreen = screenInput.currentScreen;
                }
            }
        }
    }
}