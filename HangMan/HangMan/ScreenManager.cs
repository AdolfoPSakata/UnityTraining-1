//using System.Configuration;
using StringBuffer;
using System;

namespace HangMan
{
    class ScreenManager : IScreenManager
    {
        string[,] cachedBuffer = { };
        Screens screens = new Screens();

        public void ShowScreen(string data)
        {
            Console.Clear();
            foreach (var item in data)
            {
                Console.Write(item);
            }
        }
    }
}
