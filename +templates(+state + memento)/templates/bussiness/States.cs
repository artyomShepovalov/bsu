using System.Linq;

namespace templates.bussiness
{
    public class EmptyState : IState
    {
        public void AddProduct(IProduct product, IOrder order)
        {
            order.List.Add(product);

            order.State = new NonEmptyState();
        }

        public void RemoveProduct(IProduct product, IOrder order) { }

        public int GetSumPrice(IOrder order)
        {
            return 0;
        }
    }

    public class NonEmptyState : IState
    {
        public void AddProduct(IProduct product, IOrder order)
        {
            order.List.Add(product);
        }

        public void RemoveProduct(IProduct product, IOrder order)
        {
            order.List.Remove(product);

            if(order.List.Count == 0)
            {
                order.State = new EmptyState();
            }
        }

        public int GetSumPrice(IOrder order)
        {
            return order.List.Sum(product => product.Price);
        }
    }
}
