using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerManagement.Data;
using SoccerManagement.Models.Enities;

namespace SoccerManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly SoccerManagementContext _context;
        public UsersController(SoccerManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers ()
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            
            return await _context.User.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserEntity(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var userEntity = await _context.User.FindAsync(id);

            if (userEntity == null)
            {
                return NotFound();
            }

            return userEntity;
        }

        [HttpPost]
        public async Task<ActionResult> InsertUser(User userEntity)
        {
            if (_context == null)
            {
                return Problem("Entity set 'SoccerManagementContext.UserEntity'is null.");
            }

            _context.User.Add(userEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserEntity", new { id = userEntity.Id }, userEntity);
        }
    }
}
