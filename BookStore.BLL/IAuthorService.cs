using BookStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAsync();

        Task AddAuthorAsync(Author author);

        Task UpdateAuthorAsync(Author author);

        Task DeleteAuthorAsync(int id);
    }
}