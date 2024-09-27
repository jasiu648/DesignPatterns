using DesignPatterns.Adapter;

namespace DesignPatterns.Adapter
{
    public class ExternalAPI
    {
        public void DisplayGoodMessage(StructuredMessage message)
        {
            Console.WriteLine(message.msg);
        }
    }

    public class StructuredMessage
    {
        public string? msg;

        public StructuredMessage(string? msg)
        {
            this.msg = msg;
        }
    }

    public interface IClientClass
    {
        public void DisplayMessage(Message message);
    }

    public class Message
    {
        public string? body;
    }

    public class Adapter : IClientClass
    {
        private ExternalAPI externalAPI;
        private StructuredMessage ConvertToStructuredMessage(Message message)
        {
            return new StructuredMessage(message.body);
        }

        public Adapter(ExternalAPI externalAPI)
        {
            this.externalAPI = externalAPI;
        }

        public void DisplayMessage(Message message)
        {
            var specialMessage = ConvertToStructuredMessage(message);
            externalAPI.DisplayGoodMessage(specialMessage);
        }
    }
}
class Program
{
    public static void Main()
    {
        var externalapi = new ExternalAPI();
        var adapter = new Adapter( externalapi);
        var message = new Message { body  = "Hello" };
        
        adapter.DisplayMessage(message);
    }
}