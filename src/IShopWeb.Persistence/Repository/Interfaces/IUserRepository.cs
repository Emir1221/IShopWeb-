using IShopWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShopWeb.Persistence.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);
        Task<User> GetUserByEmailAsync(string userLogin);
    }
}
