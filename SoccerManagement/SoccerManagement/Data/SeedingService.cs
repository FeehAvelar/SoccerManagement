using Microsoft.EntityFrameworkCore;
using SoccerManagement.Models.Enities;
using SoccerManagement.Models.Enums;

namespace SoccerManagement.Data
{
    public class SeedingService
    {
        private SoccerManagementContext _context;

        public SeedingService(SoccerManagementContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            this.SeedUser();
            this.SeedPlayer();
            this.SeedGame();
            await this.SeedFinancialByGames();
        }

        public void SeedUser()
        {
            if (!_context.User.Any())
            {   
                var users = new List<User>()
                {
                    new User()
                    {
                        Id= 1,
                        DateAdd= DateTime.Now,
                        Username="feeh",
                        Password="1234",
                    },
                    new User()
                    {
                        Id= 2,
                        DateAdd= DateTime.Now,
                        Username="mba",
                        Password="1234",
                    },
                    new User()
                    {
                        Id= 3,
                        DateAdd= DateTime.Now,
                        Username="ale",
                        Password="1234",
                    },
                    new User()
                    {
                        Id= 4,
                        DateAdd= DateTime.Now,
                        Username="neymar",
                        Password="1234",
                    }
                };

                _context.User.AddRange(users);
                _context.SaveChanges();
            }
        }

        public void SeedPlayer()
        {
            var noHasPlayer = !_context.Player.Any();
            var hasUsers = _context.User.Any();

            if (noHasPlayer && hasUsers)
            {
                var players = new List<Player>()
                {
                    new Player()
                    {
                        Id = 1,
                        Name = "Felipe",
                        DateAdd = DateTime.Now,
                        Surname = "Feeh",
                        Cellphone = "1992062026",
                        Email = "felipealpaca@gmail.com",
                        IdUser = 1,
                    },
                    new Player()
                    {
                        Id = 2,
                        Name = "Mauricio",
                        DateAdd = DateTime.Now,
                        Surname = "Alemao",
                        Cellphone = "19911112222",
                        Email = "mauricio@gmail.com",
                        IdUser = 2
                    },
                    new Player()
                    {
                        Id = 3,
                        Name = "Alexandre",
                        DateAdd = DateTime.Now,
                        Surname = "",
                        Cellphone = "11922226666",
                        Email = "alexandre@gmail.com",
                        IdUser = 3
                    },
                    new Player()
                    {
                        Id = 4,
                        Name = "Lucas ",
                        DateAdd = DateTime.Now,
                        Surname = "Neymar",
                        Cellphone = "19911115555",
                        Email = "neymar@gmail.com",
                        IdUser = 4
                    }
                };

                _context.Player.AddRange(players);
                _context.SaveChanges();                
            }
        }

        public void SeedGame()
        {
            var noHasGame = !_context.Game.Any();
            var hasPlayers = _context.Player.Any();

            if (noHasGame && hasPlayers)
            {
                var dataInitial = DateTime.Parse("2023-07-09T16:00");
                var existingPlayer = _context.Player.ToList();

                var playerFeeh = existingPlayer.Where(x => x.Id == 1).FirstOrDefault();
                var playerMauricio = existingPlayer.Where(x => x.Id == 2).FirstOrDefault();
                var playerAlexandre = existingPlayer.Where(x => x.Id == 3).FirstOrDefault();
                var playerNeymar = existingPlayer.Where(x => x.Id == 4).FirstOrDefault();

                var games = new List<Game>()
                {
                    new Game()
                    {
                        Id = 1,
                        DateAdd = DateTime.Now,
                        IdCreator = 1,
                        DayAmount = 80.0M,
                        GameDate = dataInitial,
                        Players = new List<Player>()
                        {
                            playerFeeh,
                            playerMauricio,
                            playerAlexandre,
                            playerNeymar
                        }
                    },
                    new Game()
                    {
                        Id = 2,
                        DateAdd = DateTime.Now,
                        IdCreator = 1,
                        DayAmount = 80.0M,
                        GameDate = dataInitial.AddDays(7),
                        Players = new List<Player>()
                        {
                            playerFeeh,
                            playerAlexandre,
                            playerNeymar
                        }
                    },
                    new Game()
                    {
                        Id = 3,
                        DateAdd = DateTime.Now,
                        IdCreator = 1,
                        DayAmount = 80.0M,
                        GameDate = dataInitial.AddDays(14),
                        Players = new List<Player>()
                        {
                            playerNeymar,
                            playerAlexandre,
                            playerMauricio
                        }
                    },
                };

                _context.Game.AddRange(games);
                _context.SaveChanges();
            }
        }

        public async Task SeedFinancialByGames()
        {
            var games = _context.Game.ToList();
            var hasGame = games.Any();
            var hasFinancial = _context.Financial.Any();

            if (!hasFinancial && hasGame)
            {
                var financialId = 1;
                foreach ( var game in games )
                {
                    var players = await _context.Player.Where(p => p.Games.Any(g => g.Id == game.Id)).ToListAsync();

                    foreach (var player in players)
                    {
                        var financial = new Financial()
                        {
                            Id = financialId,
                            IdOrigin = game.Id,
                            DateAdd = DateTime.Now,
                            Creator = game.Creator,
                            FinanceOrigin = OriginFinance.Game,
                            TypeFinance = TypeFinance.Entrada,
                            Value = decimal.ToOACurrency(game.DayAmount/players.Count),
                            DatePayment = null,
                            IdWhoChange = null,
                            //IdAccountable = player.Id
                            Accountable = player
                        };
                        _context.Financial.Add(financial);
                        _context.SaveChanges();

                        financialId++;
                    }
                }
            }
        }
    }
}
