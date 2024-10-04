using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
    public interface IService
    {
        public string ServiceOperation();
    }

    public class MessageService : IService
    {
        public string ServiceOperation()
        {
            var message = new TimeMessage();
            return message.GetMessege();
        }
    }

    public interface IMessage
    {
        public string GetMessege();
    }

    public class TimeMessage : IMessage
    {
        public string GetMessege()
        {
            DateTime now = DateTime.Now;
            return $"The current date and time is: {now}";
        }
    }
}
