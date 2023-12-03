namespace HangMan
{
    class Player
    {
        private string name;
        private int points;
        //evaluate 
        private int souls;
        private int health;

        public Player(string name, int points, int souls, int health)
        {
            this.name = name;
            this.points = points;
            this.souls = souls;
            this.health = health;
        }

        public int AddToValue(int value)
        {
            return value++;
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
