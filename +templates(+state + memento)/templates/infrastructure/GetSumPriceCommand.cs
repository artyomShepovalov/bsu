using templates.bussiness;

namespace templates.infrastructure
{
    public class GetSumPriceCommand : ICommand
    {
        private class GetSumPriceMemento : IMemento
        {
            public ICommand Command { get; set; }

            public void Restore() { }
        }

        public IOrder Order { get; set; }

        public ICommandExecutionResult Execute()
        {
            return new GetSumPriceCommandExecutionResult
                       {
                           Sum = Order.GetSumPrice(),
                           Success = true
                       };
        }

        public ICommandUndoResult Undo() 
        {
            return new GetSumPriceCommandUndoResult
                       {
                           Success = true
                       };
        }

        public IMemento GetSnapshot()
        {
            return new GetSumPriceMemento
                       {
                           Command = this
                       };
        }
    }

    public class GetSumPriceCommandExecutionResult : ICommandExecutionResult
    {
        public bool Success { get; set; }

        public int Sum { get; set; }

        public override string ToString()
        {
            return "Total:  " + Sum;
        }
    }

    public class GetSumPriceCommandUndoResult: ICommandUndoResult
    {
        public bool Success { get; set; }
    }
}