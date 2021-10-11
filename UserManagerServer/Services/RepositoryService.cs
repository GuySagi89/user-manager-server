using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagerServer.Models;

namespace UserManagerServer.Services
{
    public class RepositoryService : IRepositoryService
    {
        private IDataService _data;
        public RepositoryService(IDataService data)
        {
            _data = data;
        }

        public async Task<User> AddNewUser(User user)
        {
            var users = await _data.GetAllUsers();

            var maxId = 0;

            if (users.Any())
            {
                maxId = users.Max(u => u.Id);
            }

            var actualUser = user with
            {
                Id = maxId + 1
            };

            var updatedUsers = users.ToList();
            updatedUsers.Add(actualUser);

            await _data.UpdateUsersDB(updatedUsers);
            return actualUser;
        }

        public async Task DeleteUser(string userId)
        {
            var users = await _data.GetAllUsers();
            var updatedItems = users.Where(u => u.Id != int.Parse(userId)).ToList();
            await _data.UpdateUsersDB(updatedItems);
        }

        public async Task EditUser(User user)
        {
            var users = await _data.GetAllUsers();
            var updatedUsers = users.
             Select(u =>
             {
                 if (u.Id == user.Id)
                 {
                     return user;
                 }
                 else return u;
             }
             );
            await _data.UpdateUsersDB(updatedUsers.ToList());
        }

        public async Task<List<User>> GetAllUsers()
        {
            var list = await _data.GetAllUsers();
            return list.ToList();
        }

        public async Task<User> GetUserByID(string userId)
        {
            var users = await _data.GetAllUsers();
            return users.FirstOrDefault(u => u.Id == int.Parse(userId));
        }
    }
}
