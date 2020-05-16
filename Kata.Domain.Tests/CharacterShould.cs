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
    }
}