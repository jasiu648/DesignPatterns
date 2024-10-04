using DesignPatterns.Flyweight;

var charactersCount = 10;
var nameLength = 6;
var characterCollection = new GameCharactersCollection();

for (int i = 0; i < charactersCount; i++)
{
    var characterName = GenerateRandomString(nameLength);
    characterCollection.AddGameCharacter(characterName, 1, 1, 1);
}

characterCollection.PrintAllGameCharacters();

for(int i = 0; i < charactersCount; i++)
{
    var characterName = GenerateRandomString(nameLength);
    characterCollection.AddGameCharacter(characterName, 2, 2, 2);
}

characterCollection.PrintAllGameCharacters();


static string GenerateRandomString(int length)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    Random random = new Random();
    char[] stringChars = new char[length];

    for (int i = 0; i < length; i++)
    {
        stringChars[i] = chars[random.Next(chars.Length)];
    }

    return new string(stringChars);
}