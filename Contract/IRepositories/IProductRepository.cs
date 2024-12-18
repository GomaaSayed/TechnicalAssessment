using TechnicalAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.DTOs;


namespace TechnicalAssessment.Contract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<string> AddProductAsync(ProductDTO ProductDTO);
        Task<string> UpdateProductAsync(ProductDTO ProductDTO);
        Task<string> DeleteProductAsync(Guid ProductId);
        Task<Product> GetByProductIdAsync(Guid ProductId);
        Task<IEnumerable<ProductDTO>> GetAllProductAsync();
        Task<IEnumerable<ProductDTO>> GetAllVisibleProductsAsync();

        Task<IEnumerable<Category>> GetAllCategoryAsync();

    }

}
