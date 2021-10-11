using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagerServer.Models;
using UserManagerServer.Services;

namespace UserManagerServer.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private IRepositoryService _repo;

        public UsersController(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var allUsers = await _repo.GetAllUsers();
                return Ok(allUsers);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            try
            {
                await _repo.AddNewUser(user);
                return Ok();
            }
            catch
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByID(string id)
        {
            try
            {
                var user = await _repo.GetUserByID(id);
                return Ok(user);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditUser([FromBody] User user)
        {
            try
            {
                await _repo.EditUser(user);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(string id)
        {
            try
            {
                await _repo.DeleteUser(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
