using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechnicalAssessment.Contract.DTOs;

namespace UI.Pages
{
   

   
    public class AddInvoiceModel : PageModel
    {
        [BindProperty]
        public InvoiceDTO Invoice { get; set; }

        public void OnGet()
        {
            Invoice = new InvoiceDTO
            {
                InvoiceDate = DateTime.Now,
                Items = new List<InvoiceDetailsDTO>()
            };
        }
    }

}
