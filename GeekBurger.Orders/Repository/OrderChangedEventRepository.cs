using GeekBurger.Orders.Model;

namespace GeekBurger.Orders.Repository
{
    public class OrderChangedEventRepository : IOrderChangedEventRepository
    {
        private readonly OrdersDbContext _dbContext;

        public OrderChangedEventRepository(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderChangedEvent Get(Guid eventId)
        {
            return _dbContext.OrdersChangedEvents
                .FirstOrDefault(order => order.EventId == eventId);
        }

        public bool Add(OrderChangedEvent orderChangedEvent)
        {
            orderChangedEvent.Order =
                _dbContext.Orders
                .FirstOrDefault(_ => _.OrderId == orderChangedEvent.Order.OrderId);

            orderChangedEvent.EventId = Guid.NewGuid();

            _dbContext.OrdersChangedEvents.Add(orderChangedEvent);

            return true;
        }

        public bool Update(OrderChangedEvent orderChangedEvent)
        {
            return true;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}