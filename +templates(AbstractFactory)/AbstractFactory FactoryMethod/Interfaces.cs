using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory_FactoryMethod
{
    public interface IButton
    {
        void Paint();
    }

    public interface IGUIFactory
    {
        IButton CreateButton();
    }

}
