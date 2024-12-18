
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;

namespace TechnicalAssessment.Contract
{
    public interface IProductService
    {
        Task<string> AddProductAsync(ProductDTO ProductDTO);
        Task<string> UpdateProductAsync(ProductDTO ProductDTO);
        Task<string> DeleteProductAsync(Guid ProductId);
        Task<Product> GetByProductIdAsync(Guid ProductId);
        Task<IEnumerable<ProductDTO>> GetAllProductAsync();
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<IEnumerable<ProductDTO>> GetAllVisibleProductsAsync();


    }
}
