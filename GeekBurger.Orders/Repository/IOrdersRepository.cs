using GeekBurger.Orders.Model;

namespace GeekBurger.Orders.Repository
{
    public interface IOrdersRepository
    {
        Order GetOrderById(Guid orderId);
        bool Add(Order order);
        bool Update(Order order);
        void Delete(Order order);
        void Save();
    }
}
