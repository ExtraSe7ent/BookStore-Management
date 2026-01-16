using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public class AuthService : IAuthService
    {
        private readonly BookStoreContext _context;

        public AuthService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password && u.IsActive == true);
        }

        public async Task<bool> RegisterAsync(string username, string password, string roleName)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == username)) return false;

            var roleEntity = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (roleEntity == null) return false;

            var newUser = new User
            {
                UserName = username,
                Password = password,
                FullName = username, 
                RoleID = roleEntity.RoleID,
                IsActive = true
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}