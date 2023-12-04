using StringBuffer;

namespace HangMan
{
    interface IScreenManager
    {
        void ShowScreen(ScreensTypes.ScreenType key);
        void ChangeDictionaryText(Screens.ScreenNames key, string text);
        void SendBufferChanges(Screens.ScreenNames key);
        Screens.ScreenNames GetNextPoint();
    }
}
