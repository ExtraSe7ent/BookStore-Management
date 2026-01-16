using BookStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<bool> DeleteUserAsync(int userId);

        Task<bool> ResetPasswordAsync(int userId, string newPass);

        Task<bool> ChangePasswordAsync(int userId, string oldPass, string newPass);
    }
}