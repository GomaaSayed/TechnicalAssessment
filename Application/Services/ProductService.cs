

using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;


namespace TechnicalAssessment.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _IProductRepository;

        public ProductService(IProductRepository IProductRepository)
        {
            _IProductRepository = IProductRepository;
        }

        public async Task<string> AddProductAsync(ProductDTO Item)
        {
            return await _IProductRepository.AddProductAsync(Item);
        }

        public async Task<string> DeleteProductAsync(Guid ProductId)
        {
            return await _IProductRepository.DeleteProductAsync(ProductId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _IProductRepository.GetAllCategoryAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductAsync()
        {
            return await _IProductRepository.GetAllProductAsync();
        }

        public async Task<Product> GetByProductIdAsync(Guid ProductId)
        {
            return await _IProductRepository.GetByProductIdAsync(ProductId);
        }

        public async Task<string> UpdateProductAsync(ProductDTO ProductDTO)
        {
            return await _IProductRepository.UpdateProductAsync(ProductDTO);
        }
        public async Task<IEnumerable<ProductDTO>> GetAllVisibleProductsAsync()
        {
            return await _IProductRepository.GetAllVisibleProductsAsync();
        }
    }
}
