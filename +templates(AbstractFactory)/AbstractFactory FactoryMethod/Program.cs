using System;
using System.Configuration;

namespace AbstractFactory_FactoryMethod
{
    public class Button1 : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Button 1");
        }
    }

    public class Button2 : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Button 2");
        }
    }

    public class Button1Factory : IGUIFactory
    {
        IButton IGUIFactory.CreateButton()
        {
            return new Button1();
        }
    }

    public class Button2Factory : IGUIFactory
    {
        IButton IGUIFactory.CreateButton()
        {
            return new Button2();
        }
    }

    public class Application
    {
        public Application(IGUIFactory factory)
        {
            var button = factory.CreateButton();
            button.Paint();
        }
    }

    public class ApplicationRunner
    {
        static IGUIFactory CreateOsSpecificFactory()
        {
            Random rnd = new Random();
        
            switch (rnd.Next(1,2))
            {
                case 1:
                    return new Button1Factory();
                case 2:
                    return new Button2Factory();
                default:
                    return null;
            }
        }

        static void Main()
        {
            new Application(CreateOsSpecificFactory());
        }
    }
}
