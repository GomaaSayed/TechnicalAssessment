using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;
using TechnicalAssessment.Infrastructure.Contexts;

namespace TechnicalAssessment.Infrastructure.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(TechnicalAssessmentDbContext context) : base(context)
        {
        }

        public async Task<string> AddInvoiceAsync(Invoice invoice, List<InvoiceDetails> items)
        {
            if (invoice == null) throw new ArgumentNullException(nameof(invoice));
            if (items == null || !items.Any()) throw new ArgumentException("Invoice must contain at least one detail item.", nameof(items));
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Invoice.AddAsync(invoice);
                await _context.InvoiceDetails.AddRangeAsync(items);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return "Your invoice has been successfully saved. The invoice number is {" + invoice.InvoiceNo + "}. Thank you!"

;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Error adding the invoice. Transaction has been rolled back.", ex);
            }
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoiceAsync()
        {

            var invoices = await _context.Invoice.ToListAsync();
            var invoiceDTOs = invoices.Select(invoice => new InvoiceDTO
            {
                Id = invoice.Id,
                InvoiceNo = invoice.InvoiceNo,
                InvoiceDate = invoice.InvoiceDate,
                TotalAmount = invoice.TotalAmount,
                Description = invoice.Description,

            });

            return invoiceDTOs;
        }
        public async Task<IEnumerable<InvoiceDetailsDTO>> GetAllInvoiceDetailsAsync(Guid invoiceId)
        {

            var InvoiceDetails = await _context.InvoiceDetails.Where(s => s.InvoiceId == invoiceId).ToListAsync();
            var InvoiceDetailsMapped = InvoiceDetails.Select(invoiceD => new InvoiceDetailsDTO
            {
                Id = invoiceD.Id,
                InvoiceId = invoiceD.InvoiceId,
                Quantity = invoiceD.Quantity,
                ItemName = invoiceD.ItemId == 1 ? "Item 1" : invoiceD.ItemId == 2 ? "Item 2" : "Item 3",
                Price = invoiceD.Price,
                Total = invoiceD.Total,

            });

            return InvoiceDetailsMapped;
        }

    }
}
