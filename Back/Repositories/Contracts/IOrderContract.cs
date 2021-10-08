using BlueModasShop.Entities;
using System;
using System.Threading.Tasks;

namespace BlueModasShop.Repositories.Contracts
{
    public interface IOrderContract
    {
        Task<Order> GetOrderById(int id);
        Task<Order> SaveOrder(Order model);
    }
}
