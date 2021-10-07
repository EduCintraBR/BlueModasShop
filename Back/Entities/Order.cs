using System;
using System.Collections.Generic;

namespace BlueModasShop.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int CartId { get; set; }
        public List<Cart> Cart { get; set; }
    }
}
