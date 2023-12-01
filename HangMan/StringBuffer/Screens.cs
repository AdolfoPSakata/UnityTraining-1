using System.Collections.Generic;
using System.Configuration;

namespace StringBuffer
{
    public class Screens
    {
        BufferController bufferController = new BufferController();
        Dictionary<string, BufferChange> screenDictionary = new Dictionary<string, BufferChange>() { };
        internal int maxX = int.Parse(ConfigurationManager.AppSettings["MaxChar_X"]);
        internal int maxY = int.Parse(ConfigurationManager.AppSettings["MaxChar_Y"]);
        private string[,] cachedBuffer = new string[,] { };
        
        //think a better way
        public delegate string RequestScreen(string input);
        private enum ScreenFrames
        {
            WindowFrame,
            Circle,
            Point_1,
            Point_2,
            Point_3,
            Point_4,
            Point_5,
        }

        public string[,] ScreenConstructor()
        {
            cachedBuffer = bufferController.SetBuffer(maxX, maxY);
            foreach (string modification in bufferChanges)
            {
                cachedBuffer = bufferController.ModifyBuffer(screenDictionary[modification], cachedBuffer);
            }
            return cachedBuffer;
        }

        private string GetTextToWrite(string configKey)
        {
            string text = ConfigurationManager.AppSettings[configKey];
            return FileReader.Instance.ReadASCIIFile(text);
        }

        //CHANGE TO TOSTRING ENUM
        public string[] bufferChanges = {
              "WindowFrame",
             "Circle",
             // "Point_1",
              //"Point_2",
              //"Point_3",
              //"Point_4",
              //"Point_5",
        };

        public void CreateScreenDictionary()
        {
            screenDictionary.Add("WindowFrame", 
                new BufferChange(
                    BufferController.Mode.Block,  
                    GetTextToWrite("WindowFrame"), 0, 0));

            screenDictionary.Add("Circle", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Circle"), 10, 10));

            screenDictionary.Add( "Point_1", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_1"), 0, 0));

            screenDictionary.Add( "Point_2", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_2"), 0, 0));

            screenDictionary.Add("Point_3", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_3"), 0, 0));

            screenDictionary.Add("Point_4", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_4"), 0, 0));

            screenDictionary.Add("Point_5", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_5"), 0, 0));
        }
    }
}
