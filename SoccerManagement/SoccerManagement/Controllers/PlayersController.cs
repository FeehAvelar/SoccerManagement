using Microsoft.AspNetCore.Mvc;
using SoccerManagement.Models.Enities;

namespace SoccerManagement.Controllers
{
    public class PlayersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<PlayerEntity> GetPlayers()
        {
            var players = new List<PlayerEntity>()
            {
                new PlayerEntity(){ Id=1, Name = "Felipe" },
                new PlayerEntity(){ Id=2, Name = "Alexandre" },
            };

            return players;
        }
    }
}
