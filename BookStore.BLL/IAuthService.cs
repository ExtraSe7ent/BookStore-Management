using BookStore.Entities;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public interface IAuthService
    {
        Task<User> LoginAsync(string username, string password);

        Task<bool> RegisterAsync(string username, string password, string role);
    }
}