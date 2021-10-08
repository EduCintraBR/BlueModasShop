using System;
using System.Collections.Generic;

namespace BlueModasShop.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public decimal TotalValue { get; set; }
    }
}
