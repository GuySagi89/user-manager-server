using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagerServer.Models;

namespace UserManagerServer.Services
{
    public interface IRepositoryService
    {
        Task<User> AddNewUser(User user);
        Task DeleteUser(string userId);
        Task EditUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByID(string userId);
    }
}