using GeekBurger.Orders.Model;
using GeekBurger.Orders.Service;

namespace GeekBurger.Orders.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private OrdersDbContext _dbContext;
        private IOrderChangedService _productChangedService;

        public OrdersRepository(OrdersDbContext dbContext, IOrderChangedService productChangedService)
        {
            _dbContext = dbContext;
            _productChangedService = productChangedService;
        }

        public Order GetOrderById(Guid orderId)
        {
            return _dbContext.Orders?.FirstOrDefault(order => order.OrderId == orderId);
        }

        public bool Add(Order order)
        {
            order.OrderId = Guid.NewGuid();
            _dbContext.Orders.Add(order);
            return true;
        }

        public bool Update(Order order)
        {
            return true;
        }

        public IEnumerable<Order> GetProductsByStoreName(string storeName)
        {
            var orders = _dbContext.Orders?
                .Where(order =>
                    order.Store.Name.Equals(storeName,
                    StringComparison.InvariantCultureIgnoreCase));

            return orders;
        }

        public void Delete(Order order)
        {
            _dbContext.Orders.Remove(order);
        }

        public void Save()
        {
            _productChangedService
                .AddToMessageList(_dbContext.ChangeTracker.Entries<Order>());

            _dbContext.SaveChanges();

            _productChangedService.SendMessagesAsync();
        }
    }
}
