using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Flyweight
{
    public class GameCharacter
    {
        private string Name;
        private CharacterDesign Design;
    public GameCharacter(string name) 
        {
            Name = name;
        }

        public GameCharacter(string name, CharacterDesign design)
        {
            Name = name;
            Design = design;
        }
        public void PrintGameCharacter()
        {
            Console.WriteLine(Name);
            Design.PrintDesignInfo();
        }
    }

    public class GameCharactersCollection
    {
        private List<GameCharacter> _GameCharacters;
        public GameCharactersCollection() 
        {
            _GameCharacters = new List<GameCharacter>();
        }

        public void AddGameCharacter(string name ,int color, int width, int height)
        {
            var design = CharacterDesignCollection.GetDesignType(color, width, height);
            _GameCharacters.Add(new GameCharacter(name, design));
        }
        
        public void PrintAllGameCharacters()
        {
            foreach (var character in _GameCharacters)
            {
                character.PrintGameCharacter();
            }
        }
    }
}
