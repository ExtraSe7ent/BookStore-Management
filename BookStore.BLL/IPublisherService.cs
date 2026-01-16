using BookStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public interface IPublisherService
    {
        Task<List<Publisher>> GetAllAsync();

        Task AddPublisherAsync(Publisher publisher);

        Task UpdatePublisherAsync(Publisher publisher);

        Task DeletePublisherAsync(int id);
    }
}