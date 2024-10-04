using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Flyweight
{
    public class ZombieCharacter
    {
        public ZombieCharacter() { }
        public string Name { get; set; }
        public CharacterDesign Design { get; private set; }
        public void PrintZombie()
        {
            Console.WriteLine(Name);
            Design.PrintDesignInfo();
        }
    }

    public class ZombieCollection
    {
        private List<ZombieCharacter> _zombieCharacters;
        public ZombieCollection() 
        {
            _zombieCharacters = new List<ZombieCharacter>();
        }

        public void AddZombie()
        {

        }
        
    }
}
