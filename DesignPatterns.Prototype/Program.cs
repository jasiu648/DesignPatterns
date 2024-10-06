using DesignPatterns.Prototype;

var appComponent = new AppComponent();
appComponent.Data = 1;

var appComponentCopy = appComponent.Clone();

Console.WriteLine(appComponent.Data);
Console.WriteLine(appComponentCopy.Data);

appComponent.Data = 2;

Console.WriteLine(appComponent.Data);
Console.WriteLine(appComponentCopy.Data);


