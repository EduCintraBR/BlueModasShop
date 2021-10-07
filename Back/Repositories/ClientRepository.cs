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
    public class ClientRepository : IClientContract
    {
        private readonly ApiContext _context;

        public ClientRepository(ApiContext context)
        {
            this._context = context;
        }

        public async Task<Client> GetClientById(int id)
        {
            return await this._context.Clients.AsNoTracking()
                                              .Where(c => c.Id == id)
                                              .FirstOrDefaultAsync();
        }

        public async Task<Client> SaveClient(Client model)
        {
            try
            {
                await this._context.Clients.AddAsync(model);
                var result = await this._context.SaveChangesAsync();

                if (result > 0)
                    return model;

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
