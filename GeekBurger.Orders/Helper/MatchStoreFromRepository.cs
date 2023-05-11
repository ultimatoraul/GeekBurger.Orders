using AutoMapper;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Model;
using GeekBurger.Orders.Repository;

namespace GeekBurger.Orders.Helper
{
    public class MatchStoreFromRepository : IMappingAction<OrderToCreate, Order>
    {
        private IStoreRepository _storeRepository;
        public MatchStoreFromRepository(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void Process(OrderToCreate source, Order destination, ResolutionContext context)
        {
            var store = _storeRepository.GetStoreByName(source.StoreName);

            if (store != null)
                destination.StoreId = store.StoreId;
        }
    }
}
