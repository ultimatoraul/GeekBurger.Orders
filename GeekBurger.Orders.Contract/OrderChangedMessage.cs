namespace GeekBurger.Orders.Contract
{
    public class OrderChangedMessage
    {
        public OrderState State { get; set; }
        public OrderToGet Order { get; set; }
    }
}
