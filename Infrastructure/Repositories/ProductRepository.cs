using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;
using TechnicalAssessment.Infrastructure.Contexts;

namespace TechnicalAssessment.Infrastructure.Repositories
{

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(TechnicalAssessmentDbContext context) : base(context)
        {
        }

        // إضافة منتج جديد
        public async Task<string> AddProductAsync(ProductDTO ProductDTO)
        {

            var RST = "";
            if (ProductDTO == null)
            {
                RST = "Invalid product";
                return RST;
            }
            var existProduct = await _context.Product.FirstOrDefaultAsync(s => s.Name == ProductDTO.Name);
            if (existProduct != null)
            {
                RST = "This product is already exists in the database by same name!";
                return RST;
            }

            try
            {
                var product = new Product
                {
                    ImageUrl = ProductDTO.ImageUrl,
                    Description = ProductDTO.Description,
                    Quantity = ProductDTO.Quantity,
                    Price = ProductDTO.Price,
                    IsVisible = ProductDTO.IsVisible,
                    Name = ProductDTO.Name,
                    CategoryId = ProductDTO.CategoryId,
                    CreateBy = ProductDTO.CreateBy,
                };
                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();
                RST = "OK";
            }
            catch (Exception ex)
            {
                RST = ex.Message;
            }
            return RST;
        }

        // إضافة منتج جديد
        public async Task<string> UpdateProductAsync(ProductDTO ProductDTO)
        {
            var RST = "";
            if (ProductDTO == null)
            {
                RST = "Invalid product";
                return RST;
            }
            var existProduct = await _context.Product.FirstOrDefaultAsync(s => s.Name == ProductDTO.Name && s.Id != ProductDTO.Id);
            if (existProduct != null)
            {
                RST = "This product is already exists in the database by same name!";
                return RST;
            }
            try
            {
                var oldProduct = _context.Product.FirstOrDefault(s => s.Id == ProductDTO.Id);
                if (oldProduct == null)
                {
                    RST = "Product Not Exist!";
                    return RST;
                }

                oldProduct.ImageUrl = ProductDTO.ImageUrl;
                oldProduct.Description = ProductDTO.Description;
                oldProduct.Quantity = ProductDTO.Quantity;
                oldProduct.Price = ProductDTO.Price;
                oldProduct.Name = ProductDTO.Name;
                oldProduct.CategoryId = ProductDTO.CategoryId;
                oldProduct.CreateBy = ProductDTO.CreateBy;
                oldProduct.IsVisible = ProductDTO.IsVisible;
                await _context.SaveChangesAsync();
                RST = "OK";
            }
            catch (Exception ex)
            {
                RST = ex.Message;
            }
            return RST;
        }
        // حذف منتج بناءً على المعرف
        public async Task<string> DeleteProductAsync(Guid productId)
        {
            var RST = "";
            var product = await _context.Product.FindAsync(productId);
            if (product == null)
            {
                RST = "Product not found";
                return RST;
            }
            try
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                RST = "OK";
            }
            catch (Exception ex)
            {
                RST = ex.Message;
            }
            return RST;
        }

        // الحصول على جميع المنتجات مع تصنيفها
        public async Task<IEnumerable<ProductDTO>> GetAllProductAsync()
        {
            return await _context.Product
                .Include(p => p.Category) // تضمين التصنيفات
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name,
                    CategoryId = p.Category.Id,
                    IsVisible = p.IsVisible,
                })
                .ToListAsync();
        }

        // الحصول على منتج بناءً على المعرف
        public async Task<Product> GetByProductIdAsync(Guid productId)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllVisibleProductsAsync()
        {
            return await _context.Product.Where(s => s.IsVisible)
              .Include(p => p.Category) // تضمين التصنيفات
              .Select(p => new ProductDTO
              {
                  Id = p.Id,
                  Name = p.Name,
                  Description = p.Description,
                  Price = p.Price,
                  Quantity = p.Quantity,
                  ImageUrl = p.ImageUrl,
                  CategoryName = p.Category.Name,
                  CategoryId = p.Category.Id,
                  IsVisible = p.IsVisible,
              })
              .ToListAsync();
        }
    }

}
