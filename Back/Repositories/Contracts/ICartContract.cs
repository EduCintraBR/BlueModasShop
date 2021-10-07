using BlueModasShop.Entities;
using BlueModasShop.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModasShop.Repositories.Contracts
{
    public interface ICartContract
    {
        Task<Cart[]> GetProductCartByClientId(int id);
        Task<bool> SaveCartCheckout(List<CartProduct> product);
    }
}
