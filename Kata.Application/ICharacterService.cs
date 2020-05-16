using Kata.Domain;

namespace Kata.Application
{
    public interface ICharacterService
    {
        Character CreateCharacter();
        bool DamageCharacter(string id, int amount);
        bool HealCharacter(string id, int amount);
    }
}