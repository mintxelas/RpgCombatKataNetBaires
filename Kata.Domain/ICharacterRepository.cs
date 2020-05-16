namespace Kata.Domain
{
    public interface ICharacterRepository
    {
        Character CreateCharacter();
        Character GetCharacter(string id);
        void SaveCharacter(Character character);
    }
}