using templates.bussiness;

namespace templates.infrastructure
{
    public class AddProductCommand : ICommand
    {
        private class AddProductCommandMemento : IMemento
        {
            private readonly IOrder _order;
            private readonly IProduct _product;

            public AddProductCommandMemento(IOrder order, IProduct product)
            {
                _order = order;
                _product = product;
            }

            public ICommand Command { get; set; }

            public void Restore()
            {
                ((AddProductCommand) Command).Product = _product;
                ((AddProductCommand) Command).Order = _order;
            }
        }

        public IOrder Order { get; set; }

        public IProduct Product { get; set; }

        public ICommandExecutionResult Execute()
        {
            Order.AddProduct(Product);

            return new AddProductCommandExecutionResult
                       {
                           Success = true
                       };
        }

        public ICommandUndoResult Undo()
        {
            Order.List.Remove(Product);

            return new AddProductCommandUndoResult
                       {
                           Success = true
                       };
        }

        public IMemento GetSnapshot()
        {
            return new AddProductCommandMemento(Order, Product)
                       {
                           Command = this
                       };
        }
    }

    public class AddProductCommandExecutionResult : ICommandExecutionResult
    {
        public bool Success { get; set; }
    }

    public class AddProductCommandUndoResult : ICommandUndoResult
    {
        public bool Success { get; set; }
    }
}
