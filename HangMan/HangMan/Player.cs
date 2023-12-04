namespace HangMan
{
    class Player
    {
        private string name;
        private int health;

        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public int SubtractToValue(int value)
        {
            return value--;
        }

        public void CheckHealth()
        {
            if (health < 1)
            { 
                //end game
            }
        }
    }
}
