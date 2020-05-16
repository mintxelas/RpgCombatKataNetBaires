using Kata.Api.Controllers;
using Kata.Application;
using Kata.Domain;
using NSubstitute;
using Xunit;

namespace Kata.Api.Tests.Controllers
{
    public class CharacterControllerShould
    {
        [Fact]
        public void RelayToServiceTheCreationOfANewCharacter()
        {
            var service = Substitute.For<ICharacterService>();
            service.CreateCharacter().Returns(new Character());
            var controller = new CharacterController(service);

            var character = controller.Post();

            Assert.NotNull(character);
            service.Received().CreateCharacter();
        }
    }
}
