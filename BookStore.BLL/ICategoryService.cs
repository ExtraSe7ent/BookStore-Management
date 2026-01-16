using BookStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.BLL
{
    public interface ICategoryService
    {
        Task<List<BookCategory>> GetAllAsync();

        Task AddCategoryAsync(BookCategory category);

        Task UpdateCategoryAsync(BookCategory category);

        Task DeleteCategoryAsync(int id);
    }
}