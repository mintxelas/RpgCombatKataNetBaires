namespace Kata.Domain
{
    public class Character
    {
        public int Health { get; }
        public int Level { get; }

        public Character()
        {
            Health = 1000;
            Level = 1;
        }
    }
}