using System.Text.RegularExpressions;
using System.Configuration;
using StringBuffer;
using System.Collections.Generic;

namespace HangMan 
{
    class GuessManager
    {
        public GuessManager()
        {
            Init();
        }
        
        public string wordToGuess = "";
        public string usedLetters = "";
        readonly string path = ConfigurationManager.AppSettings["WordDatabase"];

        public void Init()
        {
            wordToGuess = ReadWordFromDatabase();
        }
        
        public string ReadWordFromDatabase()
        {
          var wordList = FileReader.Instance.ReadWordDatabase(path);
           return FileReader.Instance.GetRandomLine(wordList);
        }

        public void VerifyGuess(string guessLetter)
        {
            foreach (char letter in usedLetters)
            {
                //chnge to single chrs
                if (Regex.IsMatch(guessLetter.ToString().ToUpper(), letter.ToString().ToUpper()))
                {
                   
                    return;
                }
            }

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i].ToString().ToUpper() == guessLetter.ToUpper())
                {
                    

                    //send to screen 
                    //add points

                }
                else
                { 

                    //loose parts
                }
            }
            //end condition
            usedLetters += guessLetter;
        }
    }
}
