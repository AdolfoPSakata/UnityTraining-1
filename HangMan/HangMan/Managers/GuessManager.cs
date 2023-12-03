using StringBuffer;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;

namespace HangMan
{
    class GuessManager
    {
        public GuessManager()
        {
            Init();
        }

        private string wordToGuess = "";
        private string usedLetters = "";
        private string partialWord;
        private int remainingLetters = 100;
        //wrong place
        private int remainingLives;
        const int MAX_HEALTH = 5;
        const int MAX_QUALIFIER_TRIES = 3;
        private int wrongQualifier = 0;
        readonly string path = ConfigurationManager.AppSettings["WordDatabase"];
        private Player player = new Player("name", 0, 0, MAX_HEALTH);
        public void Init()
        {
            wordToGuess = ReadWordFromDatabase();
            partialWord = new string('_', wordToGuess.Length);
            remainingLetters = wordToGuess.Length;
            remainingLives = MAX_HEALTH;
        }

        public string ReadWordFromDatabase()
        {
            var wordList = FileReader.Instance.ReadExternalFile(path);
            return FileReader.Instance.GetRandomLine(wordList);
        }

        public string VerifyGuess(string guessLetter)
        {
            foreach (char letter in usedLetters)
            {
                if (Regex.IsMatch(NormalizeString(guessLetter), NormalizeString(Parse(letter))))
                {
                    wrongQualifier++;
                    //TODO: Migrate to appconfig
                    if (wrongQualifier < MAX_QUALIFIER_TRIES)
                        return TryGuessAgain(guessLetter);
                    else
                        //TODO: ADD MESSAGING
                        return WrongGuess();
                    //return;
                }
            }
            //end condition
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
            //TODO: change Place
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

        //TODO: send to tools
        public string NormalizeString(string stringToNormalize)
        {
            return stringToNormalize.ToUpper();
        }
        public string WrongGuess()
        {
            remainingLives--;
            if (remainingLives <= 0)
                return "DEAD";

            return partialWord;
        }

        // a bit confusing
        public string RightGuess(string guessLetter, List<int> letterIndexes)
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

        public string TryGuessAgain(string guessLetter)
        {
            //messaging
            return guessLetter + " Try Again";
        }

        //tooling
        private string Parse(char charToParse)
        {
            return charToParse.ToString();
        }

        private char Parse(string stringToParse)
        {
            return stringToParse[0];
        }
    }
}
