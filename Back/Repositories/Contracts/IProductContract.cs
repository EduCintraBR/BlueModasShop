using BlueModasShop.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModasShop.Repositories.Contracts
{
    public interface IProductContract
    {
        Task<Product[]> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> SaveProduct(Product model);
        Task<Product> UpdateProduct(int productId, Product model);
        Task<bool> RemoveProduct(int productId);
    }
}
