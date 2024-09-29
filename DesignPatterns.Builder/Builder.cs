using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public interface ICarBuilder
    {
        public void Reset();
        public void SetSeats(int seatsNumber);
        public void SetEngine(string engineIdentifier);
        public void SetComputer();
        public void SetGPS();
    }

    public class CarBuilder : ICarBuilder
    {
        public CarBuilder() { }
        private Car car;

        public void Reset()
        {
            this.car = new Car();
        }

        public void SetSeats(int seatsNumber)
        {
            this.car.SeatsNumber = seatsNumber;
        }

        public void SetEngine(string engineIdentifier)
        {
            this.car.EngineName = engineIdentifier;
        }

        public void SetComputer()
        {
            this.car.IsComputerAvailable = true;
        }

        public void SetGPS()
        {
            this.car.IsGPSAvailable = true;
        }

        public Car GetResult()
        {
            return this.car;
        }
    }

    public class CarVintageBuilder : ICarBuilder
    {
        public CarVintageBuilder() { }
        private VintageCar car;

        public void Reset()
        {
            this.car = new VintageCar();
        }

        public void SetSeats(int seatsNumber)
        {
            this.car.SeatsNumber = seatsNumber;
        }

        public void SetEngine(string engineIdentifier)
        {
            this.car.EngineName = engineIdentifier;
        }

        public void SetComputer()
        {
            this.car.IsComputerAvailable = true;
        }

        public void SetGPS()
        {
            this.car.IsGPSAvailable = true;
        }

        public VintageCar GetResult()
        {
            return this.car;
        } 
    }
}
