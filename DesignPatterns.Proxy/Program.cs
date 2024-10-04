using DesignPatterns.Proxy;

var service = new MessageService();
var proxy = new Proxy(service);


// Two times we get first time because of caching, the third time we need to make request again.
Console.WriteLine(proxy.ServiceOperation());
Thread.Sleep(3000);
Console.WriteLine(proxy.ServiceOperation());
Thread.Sleep(3000);
Console.WriteLine(proxy.ServiceOperation());