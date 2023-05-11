namespace GeekBurger.Orders.Contract
{
    public class OrderToGet
    {
        public Guid OrderId { get; set; }
        public Guid RequesterId { get; set; }
        public Guid StoreId { get; set; }
        public string? PayType { get; set; }
        public string? CardOwnerName { get; set; }
        public double CardNumber { get; set; }
        public int SecurityCode { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
