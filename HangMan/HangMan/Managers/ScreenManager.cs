using System;
using StringBuffer;

namespace HangMan
{
    //TODO: move to string buffer
    class ScreenManager : IScreenManager
    {
        Screens screens = new Screens();
        
        public void ShowScreen(ScreensTypes.ScreenType key)
        {
            string[,] currentScreen = screens.ScreenConstructor(key);
            Console.Clear();
            foreach (var character in currentScreen)
            {
                //TODO: COLOR MANAGER Integration
                Console.Write(character);
            }
        }

        public void ResetPoints()
        {
            screens.ResetPoints();
        }
        public void ResetGameScreen()
        {
            screens.ResetGameScreen();
        }
        public void SendBufferChanges(Screens.ScreenNames key)
        {
            screens.AddToRenderQueue(key);
        }

        public void ChangeDictionaryText(Screens.ScreenNames key, string text)
        {
            screens.UpdateDictionary(key, text);
        }

        public void InsertScreen(ScreensTypes.ScreenType type, Screens.ScreenNames screenName)
        {
            screens.InsertScreen(type, screenName);
        }

        Screens.ScreenNames IScreenManager.GetNextPoint()
        {
            return screens.GetNextPointScreen();
        }
    }
}
