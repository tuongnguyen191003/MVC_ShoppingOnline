using Final_ShoppingOnline.Models;
using Final_ShoppingOnline.Models.Models.ProductModel;
using System.Collections.Generic;

namespace Final_ShoppingOnline.Repository.Interfaces
{
    public interface IProductService
    {
        // Phương thức lấy danh sách sản phẩm
        IEnumerable<ProductModel> GetProducts(int? categoryId, int? brandId, string memoryFilter, int? page = 1);

        // Phương thức lấy chi tiết sản phẩm theo ID
        ProductModel GetProductById(int id);

        // Phương thức lọc sản phẩm theo mức giá
        IEnumerable<ProductModel> GetProductsByPrice(decimal? minPrice, decimal? maxPrice);

        // Phương thức tìm kiếm sản phẩm
        IEnumerable<ProductModel> SearchProducts(string keyword);

        // Phương thức lọc sản phẩm theo Memory
        IEnumerable<ProductModel> GetProductsByMemory(string memory);

        // Phương thức lấy danh sách categories
        IEnumerable<CategoryModel> GetCategories();

        // Phương thức lấy danh sách brands
        IEnumerable<BrandModel> GetBrands();

        // Phương thức lấy danh sách sản phẩm mới nhất
        IEnumerable<ProductModel> GetLatestProducts();

        // Phương thức lấy danh sách filter memory
        IEnumerable<MemoryFilterModel> GetMemoryFilters();
        // Phương thức lấy số lượng sản phẩm cho mỗi thương hiệu
        IEnumerable<BrandProductCountModel> GetBrandProductCounts();
    }
}