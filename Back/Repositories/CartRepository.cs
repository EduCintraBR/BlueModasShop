using BlueModasShop.Data.Context;
using BlueModasShop.Entities;
using BlueModasShop.Repositories.Contracts;
using BlueModasShop.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasShop.Repositories
{
    public class CartRepository : ICartContract
    {
        private readonly ApiContext _context;

        public CartRepository(ApiContext context)
        {
            this._context = context;
        }

        public async Task<Cart[]> GetProductCartByClientId(int id)
        {
            return await this._context.Carts.AsNoTracking()
                                            .Where(c => c.ClientId == id)
                                            .ToArrayAsync();
        }

        public async Task<bool> SaveCartCheckout(List<CartProduct> productCart)
        {
            try
            {
                foreach (var prod in productCart)
                {
                    var cart = new Cart
                    {
                        Name = prod.Name,
                        Price = prod.Price,
                        Quantity = prod.Quantity,
                        TotalValue = prod.TotalValue,
                        ClientId = prod.ClientId
                    };

                    await this._context.Carts.AddAsync(cart);
                }
                var result = await this._context.SaveChangesAsync();

                if (result > 0)
                    return true;

                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
