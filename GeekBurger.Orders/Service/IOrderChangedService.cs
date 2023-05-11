using GeekBurger.Orders.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GeekBurger.Orders.Service
{
    public interface IOrderChangedService : IHostedService
    {
        void SendMessagesAsync();
        void AddToMessageList(IEnumerable<EntityEntry<Order>> changes);
    }
}