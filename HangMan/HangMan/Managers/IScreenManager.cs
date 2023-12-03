using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan
{
    interface IScreenManager
    {
        void ShowScreen(string data);

        //TODO: change key to something else
        void SendBufferChanges(string key, string data);
        void RequestNameChange(string name);
    }
}
