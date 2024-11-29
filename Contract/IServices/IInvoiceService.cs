
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;

namespace TechnicalAssessment.Contract
{
    public interface IInvoiceService
    {
        Task<string> AddInvoiceAsync(InvoiceDTO Invoice);
        Task<IEnumerable<InvoiceDTO>> GetAllInvoiceAsync();
        Task<IEnumerable<InvoiceDetailsDTO>> GetAllInvoiceDetailsAsync(Guid invoiceId);

    }
}
