using StringBuffer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;

namespace HangMan
{
    class GuessManager
    {
        IScreenManager screenManager = new ScreenManager();

        Dictionary<string, string> wordDatabase = new Dictionary<string, string>()
        {
            {"1" , ConfigurationManager.AppSettings["Pride"]},
            {"2", ConfigurationManager.AppSettings["Envy"] },
            {"3" , ConfigurationManager.AppSettings["Gluttony"] },
            {"4" , ConfigurationManager.AppSettings["Lust"]},
            {"5" , ConfigurationManager.AppSettings["Wrath"]},
            {"6", ConfigurationManager.AppSettings["Greed"]},
            {"7" , ConfigurationManager.AppSettings["Sloth"]},
        };

        public string wordToGuess { get; private set; }
        private string usedLetters;
        private string partialWord;
        private int remainingLetters = 100;
        private int remainingLives;
        private int wrongQualifier = 0;

        const int MAX_HEALTH = 5;
        const int MAX_QUALIFIER_TRIES = 3;
        private void Init(string playerInput)
        {
            usedLetters = "";
            wordToGuess = ReadWordFromDatabase(playerInput);
            partialWord = new string('_', wordToGuess.Length);
            remainingLetters = wordToGuess.Length;
            remainingLives = MAX_HEALTH;
        }

        private string ReadWordFromDatabase(string path)
        {
            var wordList = FileReader.Instance.ReadExternalFile(path);
            return FileReader.Instance.GetRamdonLine(wordList);
        }

        public string VerifyGuess(string guessLetter)
        {
            foreach (char letter in usedLetters)
            {
                if (Regex.IsMatch(NormalizeString(guessLetter), NormalizeString(Parse(letter))))
                {
                    wrongQualifier++;
                    if (wrongQualifier < MAX_QUALIFIER_TRIES)
                        return TryGuessAgain(guessLetter);
                    else
                        return WrongGuess();
                }
            }
            usedLetters += guessLetter;
            List<int> letterIndexes = new List<int>();
            letterIndexes.Clear();
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (NormalizeString(Parse(wordToGuess[i])) == NormalizeString(guessLetter))
                {
                    wrongQualifier = 0;
                    letterIndexes.Add(i);
                }
            }
            wrongQualifier = 0;
            if (letterIndexes.Count > 0)
                return RightGuess(guessLetter, letterIndexes);
            else
                return WrongGuess();
        }

        internal string GetUsedLetters()
        {
            return usedLetters;
        }

        internal string GetRightLetters()
        {
            return partialWord;
        }

        private string NormalizeString(string stringToNormalize)
        {
            return stringToNormalize.ToUpper();
        }
        private string WrongGuess()
        {
            remainingLives--;
            screenManager.InsertScreen(ScreensTypes.ScreenType.Game, screenManager.GetNextPoint());

            if (remainingLives <= 0)
                return "DEAD";

            return partialWord;
        }

        private string RightGuess(string guessLetter, List<int> letterIndexes)
        {
            char[] wordArray = partialWord.ToCharArray();

            foreach (int index in letterIndexes)
            {
                wordArray[index] = Parse(guessLetter);
            }

            partialWord = string.Concat(wordArray);
            remainingLetters -= letterIndexes.Count;

            if (remainingLetters <= 0)
                return "WIN";

            return partialWord;
        }

        private string TryGuessAgain(string guessLetter)
        {
            //messaging
            return guessLetter;
        }

        private string Parse(char charToParse)
        {
            return charToParse.ToString();
        }

        private char Parse(string stringToParse)
        {
            return stringToParse[0];
        }

        internal void SelectDatabase(string playerInput)
        {
            Init(wordDatabase[playerInput]);
        }
    }
}
