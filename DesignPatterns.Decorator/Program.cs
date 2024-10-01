using DesignPatterns.Decorator;

string currentDirectory = Directory.GetCurrentDirectory();
string projectRoot = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
string filePath = Path.Combine(projectRoot, "testFile.txt");

var dataSource = new FileDataSource(filePath);
var encryptedDataSource = new EncryptionDataSourceDecorator(dataSource);

var dataFrame = new DataFrame();
dataFrame.Data = "This is test message";

encryptedDataSource.WriteData(dataFrame);


var dataFrameFromFile = encryptedDataSource.ReadData();
Console.WriteLine(dataFrameFromFile.Data);