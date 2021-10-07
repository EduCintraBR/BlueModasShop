using BlueModasShop.Entities;
using System.Threading.Tasks;

namespace BlueModasShop.Repositories.Contracts
{
    public interface IClientContract
    {
        Task<Client> GetClientById(int id);
        Task<Client> SaveClient(Client model);
    }
}
