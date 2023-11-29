using System.Text.RegularExpressions;
//using UnityTraining_1.Screens;

namespace UnityTraining_1
{
    class GuessManager
    {
        string wordToGuess = null;
        string usedLetters = null;
        public void VerifyGuess(char guessLetter)
        {
           // BufferController screenManager = new BufferController();
            foreach (char letter in usedLetters)
            {
                //chnge to single chrs
                if (Regex.IsMatch(guessLetter.ToString(), letter.ToString()))
                {
                    // retry
                }
            }

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == guessLetter)
                {
                    //send to screen 
                    //add points

                }
                else
                { }
                    //loose prt
            }
        }
    }
}
