using SoccerManagement.Models.Enities;

namespace SoccerManagement.Data
{
    public class SeedingService
    {
        private SoccerManagementContext _context;

        public SeedingService(SoccerManagementContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            this.SeedPlayerAndUser();
            this.SeedGame();

        }
        public void SeedPlayerAndUser()
        {
            if (!_context.Player.Any())
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
                        IdUser = null,                        
                        //User = new User()
                        //{
                        //    Id= 1,
                        //    DateAdd= DateTime.Now,
                        //    Username="feeh",
                        //    Password="1234",
                        //}
                    },
                    new Player()
                    {
                        Id = 2,
                        Name = "Mauricio",
                        DateAdd = DateTime.Now,
                        Surname = "Alemao",
                        Cellphone = "19911112222",
                        Email = "mauricio@gmail.com",
                        IdUser = null
                        //User = new User()
                        //{
                        //    Id= 2,
                        //    DateAdd= DateTime.Now,
                        //    Username="mba",
                        //    Password="1234",
                        //}
                    },
                    new Player()
                    {
                        Id = 3,
                        Name = "Alexandre",
                        DateAdd = DateTime.Now,
                        Surname = "",
                        Cellphone = "11922226666",
                        Email = "alexandre@gmail.com",
                        IdUser = null
                        //User = new User()
                        //{
                        //    Id= 3,
                        //    DateAdd= DateTime.Now,
                        //    Username="ale",
                        //    Password="1234",
                        //}
                    },
                    new Player()
                    {
                        Id = 5,
                        Name = "Lucas ",
                        DateAdd = DateTime.Now,
                        Surname = "Neymar",
                        Cellphone = "19911115555",
                        Email = "neymar@gmail.com",
                        IdUser = null
                        //User = new User()
                        //{
                        //    Id= 5,
                        //    DateAdd= DateTime.Now,
                        //    Username="neymar",
                        //    Password="1234",
                        //}
                    }
                };

                foreach (Player player in players)
                {   
                    _context.Player.Add(player);
                    _context.SaveChanges();                   
                }
            }
        }

        public void SeedGame()
        {
            if (!_context.Game.Any())
            {
                var dataInitial = DateTime.Parse("2023-07-09T16:00");
                var games = new List<Game>()
                {
                    new Game()
                    {
                        Id = 1,
                        DateAdd = DateTime.Now,
                        IdOwner = 1,
                        DayAmount = 80.0M,
                        GameDate = dataInitial,
                        Players = new List<Player>()
                        {
                            new Player(){Id = 1},
                            new Player(){Id = 2},
                            new Player(){Id = 3},
                            new Player(){Id = 4}
                        }
                    },
                    new Game()
                    {
                        Id = 2,
                        DateAdd = DateTime.Now,
                        IdOwner = 1,
                        DayAmount = 80.0M,
                        GameDate = dataInitial.AddDays(7),
                        Players = new List<Player>()
                        {
                            new Player(){Id = 1},
                            new Player(){Id = 3},
                            new Player(){Id = 4},
                            new Player(){Id = 5}
                        }
                    },
                    new Game()
                    {
                        Id = 3,
                        DateAdd = DateTime.Now,
                        IdOwner = 1,
                        DayAmount = 80.0M,
                        GameDate = dataInitial,
                        Players = new List<Player>()
                        {
                            new Player(){Id = 5},
                            new Player(){Id = 3},
                            new Player(){Id = 2}
                        }
                    },
                };
                _context.Game.AddRange(games);
                _context.SaveChanges();
            }                
        }


    }
}
