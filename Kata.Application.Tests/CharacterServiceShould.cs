using Kata.Domain;
using NSubstitute;
using Xunit;

namespace Kata.Application.Tests
{
    public class CharacterServiceShould
    {
        [Fact]
        public void RelayToRepositoryCreationOfNewCharacter()
        {
            var repository = Substitute.For<ICharacterRepository>();
            repository.CreateCharacter().Returns(new Character());
            var service = new CharacterService(repository);
            var character = service.CreateCharacter();
            Assert.NotNull(character);
            repository.Received().CreateCharacter();
        }
    }
}