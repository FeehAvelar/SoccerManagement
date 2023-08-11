using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerManagement.Business;
using SoccerManagement.Data;
using SoccerManagement.Models.Enities;
using SoccerManagement.Models.ViewModels;

namespace SoccerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly SoccerManagementContext _context;
        private readonly UserBusiness _userBusiness;
        private readonly PlayerBusiness _playerBusiness;

        public PlayersController(SoccerManagementContext context)
        {
            _context = context;
            _userBusiness = new UserBusiness(_context);
            _playerBusiness = new PlayerBusiness(_context);
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
            if (_context.Player == null)
            {
                return NotFound();
            }
            return await _context.Player.ToListAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayerEntity(int id)
        {
            if (_context.Player == null)
            {
                return NotFound();
            }
            var playerEntity = await _context.Player.FindAsync(id);

            if (playerEntity == null)
            {
                return NotFound();
            }

            return playerEntity;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerEntity(int id, Player playerEntity)
        {
            if (id != playerEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(playerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayer([FromBody] PlayerInsertViewModel playerInsertModel)
        {
            var playerEntity = await _playerBusiness.InsertPlayerAndUserAsync(playerInsertModel);

            return CreatedAtAction("GetPlayerEntity", new { id = playerEntity?.Id }, playerEntity);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerEntity(int id)
        {
            if (_context.Player == null)
            {
                return NotFound();
            }
            var playerEntity = await _context.Player.FindAsync(id);
            if (playerEntity == null)
            {
                return NotFound();
            }

            _context.Player.Remove(playerEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerEntityExists(int id)
        {
            return (_context.Player?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
