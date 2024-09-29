
using DesignPatterns.Builder;

var director = new Director();
var vintageBuilder = new CarVintageBuilder();
var carBuilder = new CarBuilder();

director.CreateSportsCar(carBuilder);
director.CreateBasicCar(vintageBuilder);

var resultCar = carBuilder.GetResult();
resultCar.PrintParemeters();

var resultVintage = vintageBuilder.GetResult();
resultVintage.PrintParemeters();
