using System;
using System.Collections.Generic;
using static StringBuffer.Screens;

namespace StringBuffer
{
    public class ScreensTypes
    {
        public enum ScreenType
        {
            Splash,
            Intro,
            Lose,
            Win,
            Pact,
            Menu,
            Game,
        }

        private static ScreenNames[] introScreen = {
            ScreenNames.Intro,
        };

        private static ScreenNames[] winScreen = {
            ScreenNames.Win,
        };

        private static ScreenNames[] loseScreen = {
            ScreenNames.Lose,
        };

        private static ScreenNames[] splashScreen = {
            ScreenNames.Splash,
        };

        private static ScreenNames[] pactScreen = {
            ScreenNames.Pact,
        };

        private static ScreenNames[] menuScreen = {
            ScreenNames.Menu,
        };

        private static ScreenNames[] gameScreen = {
            ScreenNames.WindowFrame,
            ScreenNames.Circle,
            ScreenNames.Angel,
            ScreenNames.WindowFrame,
            ScreenNames.Name,
            ScreenNames.UsedLetters,
            ScreenNames.GuessWord,
            ScreenNames.Message,
        };

        private ScreenNames[] gameScreenOriginal = {
            ScreenNames.WindowFrame,
            ScreenNames.Circle,
            ScreenNames.Angel,
            ScreenNames.Name,
            ScreenNames.UsedLetters,
            ScreenNames.GuessWord,
            ScreenNames.Message,
        };

        private static Dictionary<ScreenType, ScreenNames[]> screenTypesDict = new Dictionary<ScreenType, ScreenNames[]>()
        {
            {ScreenType.Splash, splashScreen},
            {ScreenType.Intro, introScreen},
            {ScreenType.Lose, loseScreen},
            {ScreenType.Win, winScreen},
            {ScreenType.Pact, pactScreen},
            {ScreenType.Menu, menuScreen},
            {ScreenType.Game, gameScreen},
        };

        public void InsertScreen(ScreenType type, ScreenNames screenName)
        {
            ScreenNames[] newScreen = new ScreenNames[screenTypesDict[type].Length+ 1];

            for (int i = 0; i < screenTypesDict[type].Length; i++)
            {
                newScreen[i] = screenTypesDict[type][i];
            }
            newScreen[newScreen.Length - 1] = screenName;
            screenTypesDict[type] = newScreen;
        }

        public void ResetGameScreen()
        {
            screenTypesDict[ScreenType.Game] = (ScreenNames[])gameScreenOriginal.Clone();
        }

        public static ScreenNames[] GetScreenConfiguration(ScreenType type)
        {
            return screenTypesDict[type];
        }
    }
}
