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