using BookStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(Invoice invoice, List<InvoiceDetail> details);

        Task<dynamic> GetInvoiceHistoryAsync();

        Task<dynamic> GetInvoiceDetailsAsync(int invoiceId);
    }
}