using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagerServer.Models;

namespace UserManagerServer.Services
{
    public interface IDataService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task UpdateUsersDB(List<User> usersChanges);
    }
}
