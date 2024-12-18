using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;
using TechnicalAssessment.Infrastructure.Contexts;

namespace TechnicalAssessment.Infrastructure.Repositories
{

    // This class represents the ProductRepository which extends the GenericRepository.
    // It provides custom implementations for product-related operations.
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TechnicalAssessmentDbContext context) : base(context)
        {
        }

        // Adds a new product to the database.
        public async Task<string> AddProductAsync(ProductDTO ProductDTO)
        {
            var RST = ""; // Holds the result status.

            // Validate the product DTO.
            if (ProductDTO == null)
            {
                RST = "Invalid product";
                return RST;
            }

            // Check if a product with the same name already exists.
            var existProduct = await _context.Product.FirstOrDefaultAsync(s => s.Name == ProductDTO.Name);
            if (existProduct != null)
            {
                RST = "This product is already exists in the database by same name!";
                return RST;
            }

            try
            {
                // Map the ProductDTO to a Product entity.
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

                // Add the product and save changes.
                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();
                RST = "OK";
            }
            catch (Exception ex)
            {
                // Handle any exception and return the error message.
                RST = ex.Message;
            }
            return RST;
        }

        // Updates an existing product in the database.
        public async Task<string> UpdateProductAsync(ProductDTO ProductDTO)
        {
            var RST = ""; // Holds the result status.

            // Validate the product DTO.
            if (ProductDTO == null)
            {
                RST = "Invalid product";
                return RST;
            }

            // Check if another product with the same name already exists.
            var existProduct = await _context.Product.FirstOrDefaultAsync(s => s.Name == ProductDTO.Name && s.Id != ProductDTO.Id);
            if (existProduct != null)
            {
                RST = "This product is already exists in the database by same name!";
                return RST;
            }

            try
            {
                // Retrieve the old product to update.
                var oldProduct = _context.Product.FirstOrDefault(s => s.Id == ProductDTO.Id);
                if (oldProduct == null)
                {
                    RST = "Product Not Exist!";
                    return RST;
                }

                // Update product properties.
                oldProduct.ImageUrl = ProductDTO.ImageUrl;
                oldProduct.Description = ProductDTO.Description;
                oldProduct.Quantity = ProductDTO.Quantity;
                oldProduct.Price = ProductDTO.Price;
                oldProduct.Name = ProductDTO.Name;
                oldProduct.CategoryId = ProductDTO.CategoryId;
                oldProduct.CreateBy = ProductDTO.CreateBy;
                oldProduct.IsVisible = ProductDTO.IsVisible;

                // Save changes to the database.
                await _context.SaveChangesAsync();
                RST = "OK";
            }
            catch (Exception ex)
            {
                // Handle any exception and return the error message.
                RST = ex.Message;
            }
            return RST;
        }

        // Deletes a product from the database by ID.
        public async Task<string> DeleteProductAsync(Guid productId)
        {
            var RST = ""; // Holds the result status.

            // Find the product by ID.
            var product = await _context.Product.FindAsync(productId);
            if (product == null)
            {
                RST = "Product not found";
                return RST;
            }

            try
            {
                // Remove the product and save changes.
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                RST = "OK";
            }
            catch (Exception ex)
            {
                // Handle any exception and return the error message.
                RST = ex.Message;
            }
            return RST;
        }

        // Retrieves all products including their categories.
        public async Task<IEnumerable<ProductDTO>> GetAllProductAsync()
        {
            return await _context.Product
                .Include(p => p.Category) // Include category details.
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

        // Retrieves a product by its ID.
        public async Task<Product> GetByProductIdAsync(Guid productId)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == productId);
        }

        // Retrieves all product categories.
        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Category.ToListAsync();
        }

        // Retrieves all visible products including their categories.
        public async Task<IEnumerable<ProductDTO>> GetAllVisibleProductsAsync()
        {
            return await _context.Product.Where(s => s.IsVisible)
                .Include(p => p.Category) // Include category details.
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
