using System;
using System.Collections.Generic;
using templates.bussiness;
using templates.infrastructure;

namespace templates
{
    class Program
    {
        static void Main()
        {
            var commandProcessor = new CommandQueueProcessor
                                        {
                                            Snapshots = new Queue<IMemento>()
                                        };
            var order = new Order
                                        {
                                            List = new List<IProduct>()
                                        };

            var addProductCommand = new AddProductCommand
                                        {
                                            Order = order,
                                            Product = new Product
                                                          {
                                                              Name = "First",
                                                              Count = 10, 
                                                              Price = 100, 
                                                          }
                                        };
            commandProcessor.AddCommandToExecute(addProductCommand);

            addProductCommand.Product = new Product
                                                 {
                                                     Count = 20, 
                                                     Price = 200, 
                                                     Name = "Secon"
                                                 };
            commandProcessor.AddCommandToExecute(addProductCommand);

            addProductCommand.Product = new Product
                                            {
                                                Count = 30,
                                                Price = 300, 
                                                Name = "Third"
                                            };
            commandProcessor.AddCommandToExecute(addProductCommand);

            commandProcessor.Run();
            commandProcessor.Run();
            commandProcessor.Run();

            var getSumPriceCommand = new GetSumPriceCommand { Order = order };
            commandProcessor.AddCommandToExecute(getSumPriceCommand);

            Console.Write(order.ToString());
            Console.WriteLine(commandProcessor.Run());
            Console.WriteLine("\n");

            commandProcessor.Undo();
            commandProcessor.AddCommandToExecute(getSumPriceCommand);
            
            Console.Write(order.ToString());
            Console.WriteLine(commandProcessor.Run());
            Console.WriteLine("\n");

            commandProcessor.Undo();
            commandProcessor.AddCommandToExecute(getSumPriceCommand);

            Console.Write(order.ToString());
            Console.WriteLine(commandProcessor.Run());
            Console.WriteLine("\n");
        }
    }
}
