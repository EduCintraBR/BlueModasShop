using BlueModasShop.Data.Context;
using BlueModasShop.Entities;
using BlueModasShop.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasShop.Repositories
{
    public class ProductRepository : IProductContract
    {
        private readonly ApiContext _context;

        public ProductRepository(ApiContext context)
        {
            this._context = context;
        }

        public async Task<Product[]> GetAllProducts()
        {
            return await this._context.Products.AsNoTracking().ToArrayAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await this._context.Products.AsNoTracking()
                                               .Where(p => p.Id == id)
                                               .FirstOrDefaultAsync();
        }

        public async Task<Product> SaveProduct(Product model)
        {
            try
            {
                await this._context.Products.AddAsync(model);
                if (await this._context.SaveChangesAsync() > 0)
                    return model;

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<Product> UpdateProduct(int productId, Product model)
        {
            try
            {
                var prod = await this.GetProductById(productId);

                if (prod == null) throw new Exception("Product for update was not found");

                model.Id = prod.Id;

                this._context.Update<Product>(model);

                if (await this._context.SaveChangesAsync() > 0)
                    return await this.GetProductById(model.Id);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        public async Task<bool> RemoveProduct(int productId)
        {
            try
            {
                var product = await this.GetProductById(productId);
                if (product == null) throw new Exception("Product for delete was not found");

                this._context.Remove<Product>(product);

                return (await this._context.SaveChangesAsync()) > 0; 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
