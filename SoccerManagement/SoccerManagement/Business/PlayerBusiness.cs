using Microsoft.EntityFrameworkCore;
using SoccerManagement.Data;
using SoccerManagement.Models.Enities;
using SoccerManagement.Models.ViewModels;

namespace SoccerManagement.Business
{
    public class PlayerBusiness
    {
        private readonly SoccerManagementContext _context;

        public PlayerBusiness(SoccerManagementContext context)
        {
            _context = context;
        }

        public async Task<Player?> InsertPlayerAsync(Player playerEntity)
        {
            _context.Player.Add(playerEntity);

            await _context.SaveChangesAsync();

            return playerEntity;
        }

        public async Task<Player?> InsertPlayerAndUserAsync(PlayerInsertViewModel playerInsertViewModel)
        {
            var userEntity = new User()
            {
                Username = playerInsertViewModel.User.UserName,
                Password = playerInsertViewModel.User.Password                
            };

            var _userBusiness = new UserBusiness(_context);

            await _userBusiness.InsertUserAsync(userEntity);

            var playerEntity = new Player()
            {
                Name = playerInsertViewModel.Name,
                Surname = playerInsertViewModel.Surname,
                Cellphone = playerInsertViewModel.Cellphone,
                Email = playerInsertViewModel.Email,
                DateAdd = DateTime.Now,
                User = userEntity
            };
            
            userEntity.Player = playerEntity;

            await _userBusiness.ChangeUserAsync(userEntity);

            return await InsertPlayerAsync(playerEntity);
        }
    }
}
