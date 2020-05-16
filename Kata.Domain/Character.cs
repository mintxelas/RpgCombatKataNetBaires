using System;

namespace Kata.Domain
{
    public class Character
    {
        public int Health { get; private set; }
        public int Level { get; }
        public string Id { get; }

        public Character()
        {
            Id = Guid.NewGuid().ToString();
            Health = 1000;
            Level = 1;
        }

        public Character(string id, int health, int level)
        {
            Id = id;
            Health = health;
            Level = level;
        }

        public bool IsALive()
        {
            return Health > 0;
        }

        public virtual void Damage(int amount)
        {
            Health = Math.Max(0, Health - amount);
        }
    }
}