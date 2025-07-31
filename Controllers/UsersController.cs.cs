using InGazAPI.Data;
using InGazAPI.Models;
using InGazAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly Repository<User> _baseReposatory;

        public UsersController(Repository<User> userRepository)
        {
            _baseReposatory = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _baseReposatory.GetAllAsync();
            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _baseReposatory.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var createdUser = await _baseReposatory.CreateAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            bool success = await _baseReposatory.UpdateAsync(user);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // You must retrieve the user object first
            var user = await _baseReposatory.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Example: Soft delete by changing status
            user.IsDeleted = true; // Or user.Status = "Inactive";

            var success = await _baseReposatory.UpdateAsync(user);
            if (!success)
            {
                return BadRequest("Failed to update user status.");
            }

            return NoContent();
        }

    }
}
