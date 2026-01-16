using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BLL
{
    public class UserService : IUserService
    {
        private readonly BookStoreContext _context;

        public UserService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;


            _context.Users.Remove(user); 
            await _context.SaveChangesAsync(); 
            return true;
        }

        public async Task<bool> ResetPasswordAsync(int userId, string newPass)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.Password = newPass;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPass, string newPass)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null && user.Password == oldPass)
            {
                user.Password = newPass;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}