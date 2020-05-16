using Xunit;

namespace Kata.Domain.Tests
{
    public class CharacterShould
    {
        private Character character;

        public CharacterShould()
        {
            character = new Character();
        }

        [Fact]
        public void BeCreatedWith1000Health()
        {
            Assert.Equal(1000, character.Health);
        }

        [Fact]
        public void BeCreatedWithLevel1()
        {
            Assert.Equal(1, character.Level);
        }

        [Fact]
        public void BeAliveWhenCreated()
        {
            Assert.True(character.IsALive());
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(10, true)]
        public void BeDeadOrAliveDependingOnItsHealth(int health, bool isAlive)
        {
            var c = new Character("123", health, 1);
            Assert.Equal(isAlive, c.IsALive());
        }

        [Theory]
        [InlineData(100, 100, 0)]
        [InlineData(100, 200, 0)]
        [InlineData(200, 100, 100)]
        public void ReduceHealthWhenDamagedWithAMinumumOfZero(int startingHealth, int receivedDamage, int finalHealth)
        {
            var c = new Character("123", startingHealth, 1);
            c.Damage(receivedDamage);
            Assert.Equal(finalHealth, c.Health);
        }

        [Theory]
        [InlineData(100, 100, 200)]
        [InlineData(0, 100, 0)]
        [InlineData(1000, 100, 1000)]
        public void IncreaseHealthUpTo1000UnlessCharacterIsDead(int startingHealth, int receivedHealing, int finalHealth)
        {
            var c = new Character("123", startingHealth, 1);
            c.Heal(receivedHealing);
            Assert.Equal(finalHealth, c.Health);
        }
    }
}