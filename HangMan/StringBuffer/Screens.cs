using System;
using System.Collections.Generic;
using System.Configuration;

namespace StringBuffer
{
    public class Screens
    {
        private string playerName = "";
        private string guessedLetters = "";
        private string usedLetters = "";
        const char heart = '\u2665';
        BufferController bufferController = new BufferController();
        Dictionary<string, BufferChange> screenDictionary = new Dictionary<string, BufferChange>() { };
        internal int maxX = int.Parse(ConfigurationManager.AppSettings["MaxChar_X"]);
        internal int maxY = int.Parse(ConfigurationManager.AppSettings["MaxChar_Y"]);
        private string[,] cachedBuffer = new string[,] { };

        //CHANGE TO TOSTRING ENUM
        public List<string> bufferChanges = new List<string>{
             "WindowFrame",
             "Health",
             "Circle",
             //"Point_1",
             //"Point_2",
             //"Point_3",
             //"Point_4",
             // "Point_5",
              "Angel"
        };

        //think a better way, maybe add to an array
        public delegate string RequestScreen(string input);
        private enum ScreenFrames
        {
            Name,
            WindowFrame,
            Circle,
            Point_1,
            Point_2,
            Point_3,
            Point_4,
            Point_5,
        }

        public void UpdateName(string key, string text)
        {
            string normalizedText = text.ToUpper().Substring(0, Math.Clamp(text.Length, 0, 20));
            playerName = normalizedText;
            UpdateDictionary(key, playerName);
        }
        public void AddToRenderQueue(string key)
        {
            bufferChanges.Add(key);
        }

        public void UpdateDictionary(string key, string value)
        {
            screenDictionary[key].toWrite = value;
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

        public void CreateScreenDictionary()
        {
            screenDictionary.Add("WindowFrame",
                new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("WindowFrame"), 0, 0));

            screenDictionary.Add("Circle", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Circle"), 4, 5));

            screenDictionary.Add("Point_1", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_1"), 16, 18));

            screenDictionary.Add("Point_2", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_2"), 12, 8));

            screenDictionary.Add("Point_3", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_3"), 12, 25));

            screenDictionary.Add("Point_4", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_4"), 6, 11));

            screenDictionary.Add("Point_5", new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite("Point_5"), 6, 22));

            screenDictionary.Add("Name", new BufferChange(
                   BufferController.Mode.Line,
                   playerName, 1, 14));

            screenDictionary.Add("GuessWord", new BufferChange(
                  BufferController.Mode.Line,
                  guessedLetters, 23, 17));

            screenDictionary.Add("UsedLetters", new BufferChange(
                  BufferController.Mode.Line,
                  usedLetters, 27, 25));

            screenDictionary.Add("Message", new BufferChange(
                  BufferController.Mode.Line,
                  "This is a test message", 28, 25));

            screenDictionary.Add("Health", new BufferChange(
                  BufferController.Mode.Line,
                  //create spaces between word
                  new string(heart, 5), 1, 68)); ;

            screenDictionary.Add("Angel", new BufferChange(
                 BufferController.Mode.Line,
                GetTextToWrite("Angel"), 5, 45)); ;
        }
    }
}
