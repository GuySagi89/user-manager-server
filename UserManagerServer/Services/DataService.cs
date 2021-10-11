using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UserManagerServer.Models;

namespace UserManagerServer.Services
{
    public class DataService : IDataService
    {
        private const string _basePath = "Data";
        private static string _usersPath = "Users.json";

        private static string _usersCombinedPath = $"{_basePath}/{_usersPath}";

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var jsonData = await File.ReadAllTextAsync(_usersCombinedPath);
            return JsonConvert.DeserializeObject<IEnumerable<User>>(jsonData);
        }
        public async Task UpdateUsersDB(List<User> usersChanges)
        {
            var changesSerialized = JsonConvert.SerializeObject(usersChanges, Formatting.Indented);
            File.WriteAllText(_usersCombinedPath, changesSerialized);
            await Task.CompletedTask;
        }
    }
}
