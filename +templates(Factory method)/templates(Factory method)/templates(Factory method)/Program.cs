using System;
using System.Collections;

class MainApp
{
    static void Main()
    {
        Maker[] Makers = new Maker[3];
        Makers[0] = new ConcreteMakerA();
        Makers[1] = new ConcreteMakerB();
        Makers[2] = new ConcreteMakerC();

        foreach (Maker Maker in Makers)
        {
            Product product = Maker.FactoryMethod();
            Console.WriteLine("Created {0}", product.GetType().Name);
        }
        Console.Read();
    }
}

abstract class Product
{
}

class ConcreteProductA : Product
{
}

class ConcreteProductB : Product
{
}

class ConcreteProductC : Product
{
}

abstract class Maker
{
    public abstract Product FactoryMethod();
}

class ConcreteMakerA : Maker
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

class ConcreteMakerB : Maker
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

class ConcreteMakerC : Maker
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductC();
    }
}