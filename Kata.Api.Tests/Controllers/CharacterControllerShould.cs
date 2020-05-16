using Kata.Api.Controllers;
using Kata.Application;
using Kata.Domain;
using NSubstitute;
using Xunit;

namespace Kata.Api.Tests.Controllers
{
    public class CharacterControllerShould
    {
        private readonly ICharacterService service;
        private readonly CharacterController controller;

        public CharacterControllerShould()
        {
            service = Substitute.For<ICharacterService>();
            controller = new CharacterController(service);
        }

        [Fact]
        public void RelayToServiceTheCreationOfANewCharacter()
        {
            service.CreateCharacter().Returns(new Character());
         
            var character = controller.Post();

            Assert.NotNull(character);
            service.Received().CreateCharacter();
        }

        [Fact]
        public void RelayToServiceTheDamagingOfExistingCharacter()
        {
            service.DamageCharacter(Arg.Any<string>(), Arg.Any<int>()).Returns(true);

            var result = controller.PutDamage("123", 10);

            Assert.True(result);
            service.Received().DamageCharacter(Arg.Is<string>(s => s == "123"), Arg.Is<int>(i => i == 10));
        }
    }
}
