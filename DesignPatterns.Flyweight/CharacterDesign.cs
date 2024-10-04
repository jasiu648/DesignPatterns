using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Flyweight
{
    public class CharacterDesign
    {
        public int Color;
        public int Width;
        public int Height;
        public CharacterDesign(int color, int width, int height)
        {
            Color = color;
            Width = width;
            Height = height;
        }

        public void PrintDesignInfo()
        {
            Console.WriteLine(Color.ToString() + " " + Width.ToString() + " " + Height.ToString()); 
        }

        public override bool Equals(object obj)
        {
            if (obj is CharacterDesign other)
            {
                return Color == other.Color && Width == other.Width && Height == other.Height;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Color, Width, Height);
        }
    }

    public static class CharacterDesignCollection
    {
        public static List<CharacterDesign> _characterDesignCollection;
        static CharacterDesignCollection()
        {
            _characterDesignCollection = new List<CharacterDesign>();
        }
        public static CharacterDesign GetDesignType(int color, int width, int height)
        {
            var tempType = new CharacterDesign(color, width, height);
            int index = _characterDesignCollection.IndexOf(tempType);

            if (index == -1)
            {
                _characterDesignCollection.Add(tempType);
                return _characterDesignCollection.Last();
            }

            return _characterDesignCollection[index];
        }
    }
}
