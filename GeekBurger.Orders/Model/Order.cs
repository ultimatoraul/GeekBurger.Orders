
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekBurger.Orders.Model
{
    public class Order
    {
        [ForeignKey("StoreId")]
        public Store? Store { get; set; }
        public Guid StoreId { get; set; }
        [Key]
        public Guid OrderId { get; set; }
        public Guid RequesterId { get; set; }
        public string? PayType { get; set; }
        public string? CardOwnerName { get; set; }
        public double CardNumber { get; set; }
        public int SecurityCode { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}