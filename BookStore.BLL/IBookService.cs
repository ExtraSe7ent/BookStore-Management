using BookStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<List<Book>> SearchBooksAsync(string keyword);

        Task AddBookAsync(Book book);

        Task UpdateBookAsync(Book book);

        Task DeleteBookAsync(int id);
    }
}