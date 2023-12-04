using System;
using StringBuffer;

namespace HangMan
{
    //TODO: move to string buffer
    class ScreenManager : IScreenManager
    {
        Screens screens = new Screens();
        //change maybe

        public void ShowScreen(ScreensTypes.ScreenType key)
        {
            //TODO: switch or state machine
            string[,] currentScreen = screens.ScreenConstructor(key);
            Console.Clear();
            foreach (var character in currentScreen)
            {
                //TODO: COLOR MANAGER Integration
                Console.Write(character);
            }
        }
        //TODO: better way maybe delegate
        public void SendBufferChanges(Screens.ScreenNames key)
        {
            screens.AddToRenderQueue(key);
        }

        public void ChangeDictionaryText(Screens.ScreenNames key, string text)
        {
            screens.UpdateDictionary(key, text);
        }

        public Screens.ScreenNames GetNextPoint()
        {
            return screens.GetNextPointScreen();
        }
    }
}
