using System;
using System.Collections.Generic;

namespace GeekBurger.Orders.Contract
{
    public class OrderToCreate
    {
        public Guid RequesterId { get; set; }
        public string? StoreName { get; set; }
        public string? PayType { get; set; }
        public string? CardOwnerName { get; set; }
        public double CardNumber { get; set; }
        public int SecurityCode { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
