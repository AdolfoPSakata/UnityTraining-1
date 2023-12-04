using System.Collections.Generic;
using System.Configuration;

namespace StringBuffer
{
    public class Screens
    {
        public Screens()
        {
            CreateScreenDictionary();
        }
        #region Enums
        public enum ScreenNames
        {
            Angel,
            Circle,
            Intro,
            Lose,
            Menu,
            Pact,
            Point_1,
            Point_2,
            Point_3,
            Point_4,
            Point_5,
            Splash,
            Win,
            WindowFrame,
            Name,
            UsedLetters,
            GuessWord,
            Message,
        }
        #endregion

        BufferController bufferController = new BufferController();
        List<ScreenNames> bufferChanges = new List<ScreenNames> { };
        Dictionary<ScreenNames, BufferChange> screenDictionary = new Dictionary<ScreenNames, BufferChange>() { };
        //TODO: EVALUATE
        delegate string RequestScreen(string input);

        int pointIndex = 0;
        private ScreenNames[] points = {
                 ScreenNames.Point_1,
                 ScreenNames.Point_2,
                 ScreenNames.Point_3,
                 ScreenNames.Point_4,
                 ScreenNames.Point_5
            };
        public ScreenNames GetNextPointScreen()
        {
            ScreenNames currentPoint = points[pointIndex];
            pointIndex++;
            return currentPoint;
        }

        private string playerName = "";
        private string guessedLetters = "";
        private string usedLetters = "";
        private string[,] cachedBuffer = new string[,] { };

        public List<ScreenNames> AddToRenderQueue(params ScreenNames[] keys)
        {
            foreach (ScreenNames name in keys)
            {
                bufferChanges.Add(name);
            }
            return bufferChanges;
        }

        public void UpdateDictionary(ScreenNames key, string value)
        {
            screenDictionary[key].toWrite = value;
        }

        public string[,] ScreenConstructor(ScreensTypes.ScreenType type)
        {
            cachedBuffer = null;
            cachedBuffer = bufferController.CreateBuffer();

            bufferChanges = AddToRenderQueue(ScreensTypes.GetScreenConfiguration(type));
            foreach (ScreenNames modification in bufferChanges)
            {
                cachedBuffer = bufferController.ModifyBuffer(screenDictionary[modification], cachedBuffer);
            }
            bufferChanges.Clear();
            return cachedBuffer;
        }

        private string GetTextToWrite(ScreenNames configKey)
        {
            string path = ConfigurationManager.AppSettings[configKey.ToString()];
            return FileReader.Instance.ReadASCIIFile(path);
        }

        public void CreateScreenDictionary()
        {
            screenDictionary.Add(ScreenNames.Angel, new BufferChange(
                 BufferController.Mode.Line,
                 GetTextToWrite(ScreenNames.Angel), 3, 45));

            screenDictionary.Add(ScreenNames.Circle, new BufferChange(
                BufferController.Mode.Block,
                GetTextToWrite(ScreenNames.Circle), 4, 5));

            screenDictionary.Add(ScreenNames.Intro, new BufferChange(
                BufferController.Mode.Block,
                GetTextToWrite(ScreenNames.Intro), 0, 0));

            screenDictionary.Add(ScreenNames.Lose, new BufferChange(
                BufferController.Mode.Block,
                GetTextToWrite(ScreenNames.Lose), 0, 0));

            screenDictionary.Add(ScreenNames.Menu, new BufferChange(
                BufferController.Mode.Block,
                GetTextToWrite(ScreenNames.Menu), 0, 0));

            screenDictionary.Add(ScreenNames.Pact, new BufferChange(
               BufferController.Mode.Block,
               GetTextToWrite(ScreenNames.Pact), 0, 0));

            screenDictionary.Add(ScreenNames.Point_1, new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite(ScreenNames.Point_1), 16, 18));

            screenDictionary.Add(ScreenNames.Point_2, new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite(ScreenNames.Point_2), 12, 8));

            screenDictionary.Add(ScreenNames.Point_3, new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite(ScreenNames.Point_3), 12, 25));

            screenDictionary.Add(ScreenNames.Point_4, new BufferChange(
                BufferController.Mode.Block,
                GetTextToWrite(ScreenNames.Point_4), 6, 11));

            screenDictionary.Add(ScreenNames.Point_5, new BufferChange(
                    BufferController.Mode.Block,
                    GetTextToWrite(ScreenNames.Point_5), 6, 22));

            screenDictionary.Add(ScreenNames.Splash, new BufferChange(
               BufferController.Mode.Block,
               GetTextToWrite(ScreenNames.Splash), 0, 0));

            screenDictionary.Add(ScreenNames.Win, new BufferChange(
               BufferController.Mode.Block,
               GetTextToWrite(ScreenNames.Win), 0, 0));

            screenDictionary.Add(ScreenNames.WindowFrame, new BufferChange(
                   BufferController.Mode.Block,
                   GetTextToWrite(ScreenNames.WindowFrame), 0, 0));

            screenDictionary.Add(ScreenNames.Name, new BufferChange(
                   BufferController.Mode.Line,
                   playerName, 1, 14));

            screenDictionary.Add(ScreenNames.GuessWord, new BufferChange(
                  BufferController.Mode.Line,
                  guessedLetters, 23, 17));

            screenDictionary.Add(ScreenNames.UsedLetters, new BufferChange(
                  BufferController.Mode.Line,
                  usedLetters, 28, 25));

            screenDictionary.Add(ScreenNames.Message, new BufferChange(
                  BufferController.Mode.Line,
                  "HEY, LISTEN!!!!", 4, 52));
        }
    }
}
