using System;

namespace HangMan
{
    class PlayerManager
    {
        public delegate int CallValueChange(Player player, int value, bool isAdding);

        public Player CreatePlayer(string name, int points, int souls, int health)
        {
            Player player = new Player(name, points, souls, health);
            CallValueChange callValueChange = new CallValueChange(ManageValues);
            return player;
        }
        public Player LoadPlayer(string name, int points, int souls, int health)
        {

            return new Player(name, points, souls, health);
        }

        public int ManageValues(Player player, int value, bool isAdding)
        {
            if (isAdding)
                player.AddToValue(value);
            else
                player.SubtractToValue(value);
            return value;
        }
        //TODO: Get value From PERSISTENT DATA



    }
}
