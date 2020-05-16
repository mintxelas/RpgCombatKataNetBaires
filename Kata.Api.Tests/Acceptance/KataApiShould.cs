using Kata.Api.Controllers;
using Kata.Application;
using Kata.Domain;
using NSubstitute;
using System;
using Xunit;

namespace Kata
{
    public class KataApiShould
    {
        private readonly ICharacterRepository repository;
        private readonly CharacterService service;
        private readonly CharacterController controller;

        public KataApiShould()
        {
            repository = Substitute.For<ICharacterRepository>();
            service = new CharacterService(repository);
            controller = new CharacterController(service);
        }

        [Fact]
        public void CreateACharacterWith1000Health()
        {
            repository.CreateCharacter().Returns(new Character());
            var character = controller.Post();
            Assert.Equal(1000, character.Health);
        }

        [Fact]
        public void CreateCharacterWithLevel1()
        {
            repository.CreateCharacter().Returns(new Character());
            var character = controller.Post();
            Assert.Equal(1, character.Level);
        }

        [Fact]
        public void CreateCharacterAsAlive()
        {
            repository.CreateCharacter().Returns(new Character());
            var character = controller.Post();
            Assert.True(character.IsALive());
        }

        [Fact]
        public void DamageACharacter()
        {
            var character = new Character("123", 123, 5);
            repository.GetCharacter("123").Returns(character);

            var result = controller.PutDamage(character.Id, 10);

            Assert.True(result);
        }

        [Fact]
        public void HealACharacter()
        {
            var character = new Character("123", 123, 4);
            repository.GetCharacter("123").Returns(character);

            bool result = controller.PutHealing(character.Id, 10);

            Assert.True(result);
        }
    }
}
