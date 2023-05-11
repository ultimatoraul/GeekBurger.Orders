using GeekBurger.Orders.Model;

namespace GeekBurger.Orders.Repository
{
    public interface IStoreRepository
    {
        Store GetStoreByName(string storeName);
    }
}
