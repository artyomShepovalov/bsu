using System.Collections.Generic;
using System.Linq;

namespace templates.bussiness
{
    public class Order : IOrder
    {
        public IList<IProduct> List { get; set; }

        public IState State { get; set; }

        public Order()
        {
            State = new EmptyState();
        }

        public void AddProduct(IProduct product)
        {
            State.AddProduct(product, this);
        }

        public void RemoveProduct(IProduct product)
        {
            State.RemoveProduct(product, this);
        }

        public int GetSumPrice()
        {
            return State.GetSumPrice(this);
        }

        public override string ToString()
        {
            return List.Aggregate("", (current, product) => current + product.ToString());
        }
    }
}