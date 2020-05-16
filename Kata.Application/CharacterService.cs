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

        public bool DamageCharacter(string id, int amount)
        {
            var character = repository.GetCharacter(id);
            character.Damage(amount);
            repository.SaveCharacter(character);
            return true;
        }

        public bool HealCharacter(string id, int amount)
        {
            var character = repository.GetCharacter(id);
            character.Heal(amount);
            repository.SaveCharacter(character);
            return true;
        }
    }
}