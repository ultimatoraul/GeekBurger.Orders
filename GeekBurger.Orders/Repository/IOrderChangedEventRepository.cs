using GeekBurger.Orders.Model;

namespace GeekBurger.Orders.Repository
{
    public interface IOrderChangedEventRepository
    {
        OrderChangedEvent Get(Guid eventId);
        bool Add(OrderChangedEvent orderChangedEvent);
        bool Update(OrderChangedEvent orderChangedEvent);
        void Save();
    }
}