using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class Car
    {
        public int SeatsNumber { get; set; }
        public string EngineName { get; set; }
        public bool IsGPSAvailable {  get; set; }
        public bool IsComputerAvailable {  get; set; }

        public virtual void PrintParemeters()
        {
            Console.WriteLine("---CAR PARAMETERS:---");
            Console.WriteLine(SeatsNumber.ToString());
            Console.WriteLine(EngineName.ToString());
            Console.WriteLine(IsGPSAvailable.ToString());
            Console.WriteLine(IsComputerAvailable.ToString());
        }
    }

    public class VintageCar : Car
    {
        public int VintageNumber { get; set; }
        public override void PrintParemeters()
        {
            base.PrintParemeters();
            Console.WriteLine(VintageNumber.ToString());
        }
    }
}
