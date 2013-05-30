using System;
using System.Collections;

namespace Flyweight
{
    class MainApp
    {
        static void Main()
        {
            int brick = 10;

            FlyweightFactory factory = new FlyweightFactory();

            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--brick);

            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--brick);

            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--brick);

            UnsharedBrickFlyweight fu = new UnsharedBrickFlyweight();

            fu.Operation(--brick);

            Console.ReadKey();
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        public FlyweightFactory()
        {
            flyweights.Add("X", new BrickFlyweight());
            flyweights.Add("Y", new BrickFlyweight());
            flyweights.Add("Z", new BrickFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }

    abstract class Flyweight
    {
        public abstract void Operation(int brick);
    }

    class BrickFlyweight : Flyweight
    {
        public override void Operation(int brick)
        {
            Console.WriteLine("BrickFlyweight: " + brick);
        }
    }

    class UnsharedBrickFlyweight : Flyweight
    {
        public override void Operation(int brick)
        {
            Console.WriteLine("UnsharedBrickFlyweight: " + brick);
        }
    }
}