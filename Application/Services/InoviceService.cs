

using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;


namespace TechnicalAssessment.Application.Services
{
    public class InoviceService : IInvoiceService
    {
        private readonly IInvoiceRepository _InvoiceRepository;

        public InoviceService(IInvoiceRepository InvoiceRepository)
        {
            _InvoiceRepository = InvoiceRepository;
        }

        public async Task<string> AddInvoiceAsync(InvoiceDTO Invoice)
        {
            Invoice invoice = new Invoice()
            {
                Id = Guid.NewGuid(),
                Description = Invoice.Description,
                InvoiceDate = Invoice.InvoiceDate,
                TotalAmount = Invoice.TotalAmount,
            };
            List<InvoiceDetails> invoiceDetailsList = new List<InvoiceDetails>();
            foreach (var detail in Invoice.Items)
            {
                InvoiceDetails invoiceDetails = new InvoiceDetails();
                invoiceDetails.Id = Guid.NewGuid();
                invoiceDetails.InvoiceId = invoice.Id;
                invoiceDetails.Quantity = detail.Quantity;
                invoiceDetails.Price = detail.Price;
                invoiceDetails.ItemId = detail.ItemId;
                invoiceDetails.Total = detail.Total;
                invoiceDetailsList.Add(invoiceDetails);
            }
            return await _InvoiceRepository.AddInvoiceAsync(invoice, invoiceDetailsList);
        }

        public Task<IEnumerable<InvoiceDTO>> GetAllInvoiceAsync()
        {
            return _InvoiceRepository.GetAllInvoiceAsync();
        }

        public Task<IEnumerable<InvoiceDetailsDTO>> GetAllInvoiceDetailsAsync(Guid invoiceId)
        {
            return _InvoiceRepository.GetAllInvoiceDetailsAsync(invoiceId);
        }
    }
}
