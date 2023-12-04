using System;

namespace HangMan
{
    class PlayerManager
    {
        public delegate int CallValueChange(Player player, int value);

        public Player CreatePlayer(string name, int health)
        {
            Player player = new Player(name, health);
            //CallValueChange callValueChange = new CallValueChange(ManageValues);
            return player;
        }
        
        public int ManageValues(Player player, int value)
        {
            player.SubtractToValue(value);
            return value;
        }
    }
}
