using Kata.Api.Controllers;
using Kata.Application;
using Kata.Domain;
using NSubstitute;
using Xunit;

namespace Kata
{
    public class KataApiShould
    {
        [Fact]
        public void CreateACharacterWith1000Health()
        {
            var repository = Substitute.For<ICharacterRepository>();
            repository.CreateCharacter().Returns(new Character());
            var service = new CharacterService(repository);
            var controller = new CharacterController(service);
            var character = controller.Post();
            Assert.Equal(1000, character.Health);
        }

        [Fact]
        public void CreateCharacterWithLevel1()
        {
            var repository = Substitute.For<ICharacterRepository>();
            repository.CreateCharacter().Returns(new Character());
            var service = new CharacterService(repository);
            var controller = new CharacterController(service);
            var character = controller.Post();
            Assert.Equal(1, character.Level);
        }
    }
}
