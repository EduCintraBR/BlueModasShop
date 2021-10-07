using BlueModasShop.Entities;
using System;

namespace BlueModasShop.ViewModel
{
    public class CartProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalValue { get; set; }

        public int? ClientId { get; set; }

        public Guid? OrderId { get; set; }
    }
}
