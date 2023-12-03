using StringBuffer;
using System;

namespace HangMan
{
    class ScreenManager : IScreenManager
    {
        Screens screens = new Screens();
        public ScreenManager()
        {
            screens.CreateScreenDictionary();
        }

        public void ShowScreen(string data)
        {
            //TODO: switch or state machine
            string[,] currentScreen = screens.ScreenConstructor();
            Console.Clear();
            foreach (var character in currentScreen)
            {
                //TODO: make a color controler, or tool
                if (character == " ")
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                else if (character == "&")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                }

                Console.Write(character);
            }
        }
        //TODO: better way
        public void SendBufferChanges(string key, string text)
        {
            screens.UpdateDictionary(key, text);
            //split this
            screens.AddToRenderQueue(key);
        }

        public void RequestNameChange(string text)
        {
            screens.UpdateName("Name", text);
        }
    }
}
