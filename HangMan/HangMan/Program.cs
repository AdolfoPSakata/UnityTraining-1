using System;

namespace HangMan
{
    class Program
    {
        public delegate string ProcessString(string input);

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool isPlaying = false;
            IScreenManager screenManager = new ScreenManager();
            InputManager inputManager = new InputManager();
            GuessManager guessManager = new GuessManager();
            Console.WriteLine("-------------Enter your Name---------------");

            //TODO: name to something more fool proof

            string playerName = Console.ReadLine();

            //merge this shit
            screenManager.RequestNameChange(playerName);
            screenManager.SendBufferChanges("Name", playerName);


            string rightLetters = guessManager.GetRightLetters();
            screenManager.SendBufferChanges("GuessWord", rightLetters);
            //---------------
            
            //create game
            isPlaying = true;
            //TODO: Fix tahat
            screenManager.ShowScreen(" ");

            while (isPlaying)
            {
                string playerInput = inputManager.ReadInput(Console.ReadLine());

                if (!string.IsNullOrEmpty(playerInput))
                {
                    rightLetters = guessManager.VerifyGuess(playerInput);
                    string usedLetters = guessManager.GetUsedLetters();
                    screenManager.SendBufferChanges("GuessWord", rightLetters);
                    screenManager.SendBufferChanges("UsedLetters", usedLetters);

                    if (rightLetters == "WIN" || rightLetters == "DEAD")
                    {
                        screenManager.SendBufferChanges("Message", rightLetters);
                    }
                    screenManager.ShowScreen(" ");
                }
            }
            screenManager.ShowScreen(" ");
            Console.WriteLine("-------------END---------------" + rightLetters);
            Console.ReadLine();
        }


    }
}