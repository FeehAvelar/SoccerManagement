using Microsoft.EntityFrameworkCore;
using SoccerManagement.Data;
using SoccerManagement.Models.Enities;

namespace SoccerManagement.Business
{
    public class UserBusiness
    {
        private readonly SoccerManagementContext _context;

        public UserBusiness(SoccerManagementContext context)
        {
            _context = context;
        }

        private bool UserEntityExists(int id)
        {
            return (_context.User?.Any(u => u.Id == id)).GetValueOrDefault();
        }
    
        private void ValidateUserIsNull(User user) 
        { 
            if (user == null)
                throw new Exception("User can't is null");
        }

        public async Task<User> ChangeUserAsync(User user)
        {
            ValidateUserIsNull(user);

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                
                return user;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<User?> InsertUserAsync(User userEntity)
        {
            userEntity.DateAdd = DateTime.Now;

            ValidateUserIsNull(userEntity);

            _context.User.Add(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }

    }
}
