using StringBuffer;
using System;

namespace HangMan
{
    class ScreenManager : IScreenManager
    {
        public ScreenManager()
        {
            screens.CreateScreenDictionary();
        }

        Screens screens = new Screens();

        public void ShowScreen(string data)
        {
            //TODO: switch or state machine
            string[,] test = { };
            test = screens.ScreenConstructor();
            Console.Clear();
            foreach (var item in test)
            {

                if (item == " ")
                    Console.BackgroundColor = ConsoleColor.Black;
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                Console.Write(item);
            }
        }
    }
}
