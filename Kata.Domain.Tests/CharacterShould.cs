using Xunit;

namespace Kata.Domain.Tests
{
    public class CharacterShould
    {
        [Fact]
        public void BeCreatedWith1000Health()
        {
            var character= new Character();
            Assert.Equal(1000, character.Health);
        }

        [Fact]
        public void BeCreatedWithLevel1()
        {
            var character = new Character();
            Assert.Equal(1, character.Level);
        }
    }
}