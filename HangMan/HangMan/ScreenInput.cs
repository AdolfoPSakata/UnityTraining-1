using StringBuffer;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HangMan
{
    class ScreenInput
    {
        IScreenManager screenManager = new ScreenManager();

        readonly InputOption key_Any;
        readonly InputOption key_P;
        readonly InputOption key_X;
        readonly InputOption key_R;
        readonly InputOption key_S;

        readonly InputOption key_1;
        readonly InputOption key_2;
        readonly InputOption key_3;
        readonly InputOption key_4;
        readonly InputOption key_5;
        readonly InputOption key_6;
        readonly InputOption key_7;

        public Dictionary<string, InputOption> introScreen;
        public Dictionary<string, InputOption> menuScreen;
        public Dictionary<string, InputOption> winScreen;
        public Dictionary<string, InputOption> loseScreen;
        public Dictionary<string, InputOption> gameScreen;
        public Dictionary<string, InputOption> pactScreen;
        public ScreensTypes.ScreenType currentScreen;
        public Dictionary<ScreensTypes.ScreenType, Dictionary<string, InputOption>> currentScreenDict;
        GuessManager guessManager = new GuessManager();
        InputManager inputManager = new InputManager();
        string rightLetters;
        string usedLetters;
        string playerInput;
        Action updateGame;
        public ScreenInput()
        {

            updateGame = new Action(UpdateGame);

            key_Any = new InputOption(null, StartGame);
            key_P = new InputOption("P", StartGame);
            key_X = new InputOption("X", ExitGame);
            key_R = new InputOption("R", ReturnToMenu);
            key_S = new InputOption("S", Replay);

            key_1 = new InputOption("1", SelectDatabase);
            key_2 = new InputOption("2", SelectDatabase);
            key_3 = new InputOption("3", SelectDatabase);
            key_4 = new InputOption("4", SelectDatabase);
            key_5 = new InputOption("5", SelectDatabase);
            key_6 = new InputOption("6", SelectDatabase);
            key_7 = new InputOption("7", SelectDatabase);

            Init();
        }

        private void Init()
        {
            menuScreen = new Dictionary<string, InputOption>
            {
                {"P", key_P },
                {"X", key_X },
            };
            loseScreen = new Dictionary<string, InputOption>
            {
                { "R", key_R },
            };
            winScreen = new Dictionary<string, InputOption>
            {
                { "R", key_R },
                { "S", key_S },
            };
            introScreen = new Dictionary<string, InputOption>
            {
                { "1", key_1 },
                { "2", key_2 },
                { "3", key_3 },
                { "4", key_4 },
                { "5", key_5 },
                { "6", key_6 },
                { "7", key_7 },
            };
            gameScreen = new Dictionary<string, InputOption> { };
            pactScreen = new Dictionary<string, InputOption> { };

            currentScreenDict = new Dictionary<ScreensTypes.ScreenType, Dictionary<string, InputOption>>
            {
                {ScreensTypes.ScreenType.Menu, menuScreen },
                {ScreensTypes.ScreenType.Lose, loseScreen },
                {ScreensTypes.ScreenType.Win, winScreen },
                {ScreensTypes.ScreenType.Intro, introScreen },
                {ScreensTypes.ScreenType.Game, gameScreen },
                {ScreensTypes.ScreenType.Pact, pactScreen },
            };
        }

        public Action GetInputOption(string key, ScreensTypes.ScreenType type)
        {
            playerInput = key;
            Action action;
            try
            {
                action = currentScreenDict[type][key.ToUpper()].action;
            }
            catch (Exception)
            {
                if (type == ScreensTypes.ScreenType.Game)
                {
                    action = updateGame;
                }
                else
                {
                    screenManager.ShowScreen(type);
                    action = null;
                }
            }
            return action;
        }
        private void Replay()
        {
            screenManager.ShowScreen(ScreensTypes.ScreenType.Intro);
            currentScreen = ScreensTypes.ScreenType.Intro;
        }

        private void ReturnToMenu()
        {
            screenManager.ShowScreen(ScreensTypes.ScreenType.Menu);
            currentScreen = ScreensTypes.ScreenType.Menu;
        }

        public void StartGame()
        {
            screenManager.ShowScreen(ScreensTypes.ScreenType.Intro);
            currentScreen = ScreensTypes.ScreenType.Intro;
        }
        public void ExitGame()
        {
            Environment.Exit(0);
        }

        public void SelectDatabase()
        {
            screenManager.ShowScreen(ScreensTypes.ScreenType.Pact);

            string playerName = Console.ReadLine();
            screenManager.ChangeDictionaryText(Screens.ScreenNames.Name, playerName);
            screenManager.SendBufferChanges(Screens.ScreenNames.Name);

            rightLetters = guessManager.GetRightLetters();
            screenManager.ChangeDictionaryText(Screens.ScreenNames.GuessWord, rightLetters);
            screenManager.ShowScreen(ScreensTypes.ScreenType.Game);
            currentScreen = ScreensTypes.ScreenType.Game;
        }

        public void UpdateGame()
        {
            playerInput = inputManager.ReadInput(playerInput);

            if (!string.IsNullOrEmpty(playerInput))
            {
                rightLetters = guessManager.VerifyGuess(playerInput);
                usedLetters = guessManager.GetUsedLetters();
                screenManager.ChangeDictionaryText(Screens.ScreenNames.GuessWord, rightLetters);
                screenManager.ChangeDictionaryText(Screens.ScreenNames.UsedLetters, usedLetters);
                screenManager.ShowScreen(ScreensTypes.ScreenType.Game);

                if (rightLetters == "WIN")
                {
                    Thread.Sleep(3000);
                    screenManager.ShowScreen(ScreensTypes.ScreenType.Win);
                    currentScreen = ScreensTypes.ScreenType.Win;
                    return;
                }
                else if (rightLetters == "DEAD")
                {
                    Thread.Sleep(3000);
                    screenManager.ShowScreen(ScreensTypes.ScreenType.Lose);
                    currentScreen = ScreensTypes.ScreenType.Lose;
                    return;
                }
            }
            screenManager.ShowScreen(ScreensTypes.ScreenType.Game);
            currentScreen = ScreensTypes.ScreenType.Game;
        }
    }
}
