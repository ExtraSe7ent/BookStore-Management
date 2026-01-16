using BookStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.BLL
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();

        Task<List<Customer>> SearchCustomerAsync(string keyword);

        Task AddCustomerAsync(Customer c);

        Task UpdateCustomerAsync(Customer c);

        Task DeleteCustomerAsync(int id);
    }
}