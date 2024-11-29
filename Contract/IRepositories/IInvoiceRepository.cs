using TechnicalAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.DTOs;


namespace TechnicalAssessment.Contract
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task<string> AddInvoiceAsync(Invoice Item,List<InvoiceDetails> Items);
        Task<IEnumerable<InvoiceDTO>> GetAllInvoiceAsync();
        Task<IEnumerable<InvoiceDetailsDTO>> GetAllInvoiceDetailsAsync(Guid invoiceId);

    }

}
