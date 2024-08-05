using Final_ShoppingOnline.Models;
using Final_ShoppingOnline.Models.Models.ProductModel;
using Final_ShoppingOnline.Repository.Data;
using Final_ShoppingOnline.Repository.Interfaces;
using System.Collections.Generic;

namespace Final_ShoppingOnline.Repository.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        // Phương thức lấy danh sách sản phẩm
        public IEnumerable<ProductModel> GetProducts(int? categoryId, int? brandId, string memoryFilter, int? page = 1)
        {
            var products = _context.Products.AsQueryable();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            if (brandId.HasValue)
            {
                products = products.Where(p => p.BrandId == brandId);
            }

            if (!string.IsNullOrEmpty(memoryFilter))
            {
                products = products.Where(p => p.Options.Any(o => o.Type == OptionTypeModel.RAM && o.Value == memoryFilter));
            }

            // Phân trang
            if (page.HasValue)
            {
                int pageSize = 12; // Kích thước mỗi trang
                products = products.Skip((page.Value - 1) * pageSize).Take(pageSize);
            }

            return products.ToList();
        }

        // Phương thức lấy chi tiết sản phẩm theo ID
        public ProductModel GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        // Phương thức lọc sản phẩm theo mức giá
        public IEnumerable<ProductModel> GetProductsByPrice(decimal? minPrice, decimal? maxPrice)
        {
            var products = _context.Products.AsQueryable();

            if (minPrice.HasValue)
            {
                products = products.Where(p => p.SalePrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.SalePrice <= maxPrice.Value);
            }

            return products.ToList();
        }

        // Phương thức tìm kiếm sản phẩm
        public IEnumerable<ProductModel> SearchProducts(string keyword)
        {
            return _context.Products.Where(p => p.Name.Contains(keyword)).ToList();
        }

        // Phương thức lọc sản phẩm theo Memory
        public IEnumerable<ProductModel> GetProductsByMemory(string memory)
        {
            return _context.Products.Where(p => p.Options.Any(o => o.Type == OptionTypeModel.RAM && o.Value == memory)).ToList();
        }

        // Phương thức lấy danh sách categories
        public IEnumerable<CategoryModel> GetCategories()
        {
            return _context.Categories.ToList();
        }

        // Phương thức lấy danh sách brands
        public IEnumerable<BrandModel> GetBrands()
        {
            return _context.Brands.ToList();
        }

        // Phương thức lấy danh sách sản phẩm mới nhất
        public IEnumerable<ProductModel> GetLatestProducts()
        {
            return _context.Products.OrderByDescending(p => p.Id).Take(8).ToList();
        }

        // Phương thức lấy danh sách filter memory
        public IEnumerable<MemoryFilterModel> GetMemoryFilters()
        {
            // Logic lấy dữ liệu filter memory
            // ...
            return new List<MemoryFilterModel>
            {
                new MemoryFilterModel { Value = "8GB", Quantity = 8 },
                new MemoryFilterModel { Value = "16GB", Quantity = 9 },
                new MemoryFilterModel { Value = "32GB", Quantity = 7 },
                new MemoryFilterModel { Value = "64GB", Quantity = 9 },
                new MemoryFilterModel { Value = "128GB", Quantity = 12 },
                new MemoryFilterModel { Value = "256GB", Quantity = 12 },
                new MemoryFilterModel { Value = "512GB", Quantity = 12 },
                new MemoryFilterModel { Value = "1TB", Quantity = 12 }
            };
        }

        public IEnumerable<BrandProductCountModel> GetBrandProductCounts()
        {
            return _context.Brands
                .Select(b => new BrandProductCountModel
                {
                    BrandId = b.Id,
                    Count = b.Products.Count()
                })
                .ToList();
        }
    }
}