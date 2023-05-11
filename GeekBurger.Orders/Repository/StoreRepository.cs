using GeekBurger.Orders.Model;

namespace GeekBurger.Orders.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private OrdersDbContext _context { get; set; }

        public StoreRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public Store GetStoreByName(string storeName)
        {
            return _context.Stores.FirstOrDefault(store => store.Name.Equals(storeName, StringComparison.InvariantCultureIgnoreCase));   
        }
    }
}
