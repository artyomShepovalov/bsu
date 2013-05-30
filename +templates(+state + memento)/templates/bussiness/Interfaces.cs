using System;
using System.Collections.Generic;

namespace templates.bussiness
{
    public interface IProduct
    {
        int Price { get; set; }

        string Name { get; set; }
    }

    public interface IOrder
    {
        IList<IProduct> List { get; set; }

        IState State { get; set; }

        void AddProduct(IProduct product);

        void RemoveProduct(IProduct product);

        int GetSumPrice();
    }

    public interface IState
    {
        void AddProduct(IProduct product, IOrder order);

        void RemoveProduct(IProduct product, IOrder order);

        int GetSumPrice(IOrder order);
    }
}
