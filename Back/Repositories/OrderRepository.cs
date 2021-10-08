using BlueModasShop.Data.Context;
using BlueModasShop.Entities;
using BlueModasShop.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasShop.Repositories
{
    public class OrderRepository : IOrderContract
    {
        private readonly ApiContext _context;

        public OrderRepository(ApiContext context)
        {
            this._context = context;
        }

        public async Task<Order> GetOrderById(int id)
        {
            IQueryable<Order> query = this._context.Orders.AsNoTracking()
                                      .Where(o => o.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Order> SaveOrder(Order model)
        {
            try
            {
                this._context.Add<Order>(model);

                if (await this._context.SaveChangesAsync() > 0)
                    return await this.GetOrderById(model.Id);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
