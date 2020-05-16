using Kata.Domain;

namespace Kata.Application
{
    public class CharacterService: ICharacterService
    {
        private readonly ICharacterRepository repository;

        public CharacterService(ICharacterRepository repository)
        {
            this.repository = repository;
        }

        public Character CreateCharacter()
        {
            return repository.CreateCharacter();
        }
    }
}