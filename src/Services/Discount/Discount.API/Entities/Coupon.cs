﻿namespace Discount.API.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Decription { get; set; }
        public int Amount { get; set; }
    }
}
