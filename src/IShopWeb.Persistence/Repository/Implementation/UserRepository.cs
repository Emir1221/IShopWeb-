using IShopWeb.Domain.Models;
using IShopWeb.Persistence.Data;
using IShopWeb.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShopWeb.Persistence.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _appDbContext; //TODO нормально ли так делать или создать интерфейс

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task CreateUserAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Users.Remove(user); //TODO можно сделать так чтоб удалить одним запросом и не искать из бд по id
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users.AsNoTracking().ToListAsync();
        }

        public Task<User> GetUserByEmailAsync(string userLogin)
        {
            return _appDbContext.Users.FirstOrDefaultAsync(x => x.Login == userLogin);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateUserAsync(User user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
