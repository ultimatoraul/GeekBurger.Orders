using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekBurger.Orders.Contract;

namespace GeekBurger.Orders.Model
{
    public class OrderChangedEvent
    {
        [Key]
        public Guid EventId { get; set; }

        public OrderState State { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        public bool MessageSent { get; set; }
    }
}