using Kata.Domain;
using NSubstitute;
using Xunit;

namespace Kata.Application.Tests
{
    public class CharacterServiceShould
    {
        private readonly ICharacterRepository repository;
        private readonly CharacterService service;

        public CharacterServiceShould()
        {
            repository = Substitute.For<ICharacterRepository>();
            service = new CharacterService(repository);
        }

        [Fact]
        public void RelayToRepositoryCreationOfNewCharacter()
        {
            repository.CreateCharacter().Returns(new Character());
            
            var character = service.CreateCharacter();

            Assert.NotNull(character);
            repository.Received().CreateCharacter();
        }

        [Fact]
        public void DamageCharacterFromRepository()
        {
            var existingCharacter = Substitute.For<Character>("123", 123, 123);
            repository.GetCharacter(Arg.Any<string>()).Returns(existingCharacter);
            var result = service.DamageCharacter("123", 10);
            repository.Received().GetCharacter("123");
            existingCharacter.Received().Damage(Arg.Is<int>(i => i == 10));
            repository.Received().SaveCharacter(Arg.Is<Character>(ch => ch.Id == "123"));
        }
    }
}