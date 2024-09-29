using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class Director
    {  
        public void CreateBasicCar(ICarBuilder carBuilder)
        {
            carBuilder.Reset();
            carBuilder.SetSeats(5);
            carBuilder.SetEngine("Basic Diesel");
            carBuilder.SetGPS();
            
        }

        public void CreateSportsCar(ICarBuilder carBuilder) 
        {
            carBuilder.Reset();
            carBuilder.SetSeats(2);
            carBuilder.SetEngine("Super Diesel");
            carBuilder.SetComputer();
        }
    }
}
