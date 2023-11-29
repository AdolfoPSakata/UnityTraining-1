using System;
//using System.Configuration;
using StringBuffer;

namespace UnityTraining_1
{
    class ScreenManager
    { 
    //    int maxX = int.Parse(ConfigurationManager.AppSettings["MaxChar_X"]);
    //    int maxY = int.Parse(ConfigurationManager.AppSettings["MaxChar_Y"]);
        string cachedName = null;
        string[,] cachedBuffer = { };
        Screens screens = new Screens();
        //Screens screens = new Screens.Screens();
        //public ScreenManager()
        //{

        //}

        

       public void ShowScreen()
        {
            cachedBuffer = screens.test();
            foreach (var item in cachedBuffer)
            {
                Console.Clear();
                Console.Write(item);
            }
        }

        public string ShowName()
        {
            string playersName = Console.ReadLine();
            return playersName;
        }

       
    }
}
