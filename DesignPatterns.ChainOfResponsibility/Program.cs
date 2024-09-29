namespace DesignPatterns.ChainOfResponsibility
{
    public interface IChainHandler
    {
        public void SetNext(IChainHandler nextHandler);
        public void Handle(ChainRequest chainRequest);
    }

    public abstract class BaseChainHandler : IChainHandler
    {
        protected IChainHandler? nextHandler;
        public abstract void Handle(ChainRequest chainRequest);

        public void SetNext(IChainHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }
    }

    public class ImportantMessageHandler : BaseChainHandler
    {
        public override void Handle(ChainRequest chainRequest)
        {
            if(chainRequest.IsImportant())
                chainRequest.PrintMessage();

            if (this.nextHandler is not null)
                this.nextHandler.Handle(chainRequest);
        }
    }

    public class AllMessageHandler : BaseChainHandler
    {
        public override void Handle(ChainRequest chainRequest)
        {
            chainRequest.PrintMessage();

            if (this.nextHandler is not null)
                this.nextHandler.Handle(chainRequest);
        }
    }


    public abstract class ChainRequest
    {
        protected readonly int userId;
        protected readonly string message;

        protected ChainRequest(int userId, string message)
        {
            this.userId = userId;
            this.message = message;
        }

        public abstract void PrintMessage();
        public abstract bool IsImportant();
    }

    public class HRRequest : ChainRequest
    {
        public HRRequest(int userId, string message) : base(userId,message) {}

        public override bool IsImportant()
        {
            return true;
        }

        public override void PrintMessage()
        {
            Console.WriteLine($"HR MESSAGE FROM {this.userId} \n ---{this.message}");
        }
    }

    public class DevRequest : ChainRequest
    {
        public DevRequest(int userId, string message) : base(userId, message) { }

        public override void PrintMessage()
        {
            Console.WriteLine($"DEV MESSAGE FROM {this.userId} \n ---{this.message}");
        }
        public override bool IsImportant()
        {
            return false;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var importantHandlerInstance = new ImportantMessageHandler();
            var allHandlerInstance = new AllMessageHandler();

            var messegeFromDev = new DevRequest(334, "I need access to Azure");
            var messegeFromHR = new HRRequest(12, "Pizza in Open-Space!");

            importantHandlerInstance.SetNext(allHandlerInstance);
            importantHandlerInstance.Handle(messegeFromHR);
            importantHandlerInstance.Handle(messegeFromDev);
        }
    }
}