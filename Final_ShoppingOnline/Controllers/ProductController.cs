using Microsoft.AspNetCore.Mvc;
using Final_ShoppingOnline.Repository.Interfaces;
using Final_ShoppingOnline.Models;
using Final_ShoppingOnline.Models.Models.ProductModel;
using Microsoft.AspNetCore.Http;

namespace Final_ShoppingOnline.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int? categoryId, int? brandId, string memoryFilter, string sortOrder, int? page = 1)
        {
            // Lấy danh sách sản phẩm từ service
            var products = _productService.GetProducts(categoryId, brandId, memoryFilter, sortOrder, page);

            // Kiểm tra xem có sản phẩm nào được tìm thấy hay không
            if (products == null || !products.Any())
            {
                return View("Empty");
            }

            // Lấy danh sách categories, brands, latestProducts và memoryFilters từ service
            var categories = _productService.GetCategories();
            var brands = _productService.GetBrands();
            var latestProducts = _productService.GetLatestProducts();
            var memoryFilters = _productService.GetMemoryFilters();

            // Lấy số lượng sản phẩm cho mỗi thương hiệu
            var brandCounts = _productService.GetBrandProductCounts();

            // Truyền dữ liệu vào view
            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            ViewBag.LatestProducts = latestProducts;
            ViewBag.MemoryFilters = memoryFilters;
            ViewBag.BrandCounts = brandCounts;
            ViewBag.CategoryId = categoryId;
            ViewBag.BrandId = brandId;
            ViewBag.MemoryFilter = memoryFilter;
            ViewBag.SortOrder = sortOrder;

            // Lấy tổng số trang và trang hiện tại
            ViewBag.TotalPages = _productService.GetTotalPages(categoryId, brandId, memoryFilter, sortOrder, 12);
            ViewBag.CurrentPage = page;

            return View(products);
        }

        public IActionResult Details(int id)
        {
            // Lấy sản phẩm từ service
            var product = _productService.GetProductById(id);

            // Kiểm tra xem sản phẩm có tồn tại hay không
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Lọc sản phẩm theo mức giá
        public IActionResult FilterByPrice(decimal? minPrice, decimal? maxPrice)
        {
            // Lấy danh sách sản phẩm đã lọc theo mức giá từ service
            var products = _productService.GetProductsByPrice(minPrice, maxPrice);

            // Truyền danh sách sản phẩm đã lọc vào view
            return View("Index", products);
        }

        // Action xử lý phân trang (Previous)
        public IActionResult Previous(int? page, int? categoryId, int? brandId, string memoryFilter, string sortOrder)
        {
            // Lấy danh sách sản phẩm từ service, sử dụng page để phân trang
            var products = _productService.GetProducts(categoryId, brandId, memoryFilter, sortOrder, page - 1);

            // Truyền danh sách sản phẩm vào view
            return View("Index", products);
        }

        // Action xử lý phân trang (Next)
        public IActionResult Next(int? page, int? categoryId, int? brandId, string memoryFilter, string sortOrder)
        {
            // Lấy danh sách sản phẩm từ service, sử dụng page để phân trang
            var products = _productService.GetProducts(categoryId, brandId, memoryFilter, sortOrder, page + 1);

            // Truyền danh sách sản phẩm vào view
            return View("Index", products);
        }

        // Action xử lý tìm kiếm sản phẩm
        public IActionResult Search(string keyword)
        {
            // Lấy danh sách sản phẩm từ service, sử dụng keyword để tìm kiếm
            var products = _productService.SearchProducts(keyword);

            // Truyền danh sách sản phẩm vào view
            return View("Index", products);
        }

        // Action xử lý lọc sản phẩm theo Memory
        public IActionResult FilterByMemory(string memory)
        {
            // Lấy danh sách sản phẩm từ service, sử dụng memory để lọc
            var products = _productService.GetProductsByMemory(memory);

            // Truyền danh sách sản phẩm vào view
            return View("Index", products);
        }

        // Action xử lý sắp xếp theo tên
        public IActionResult SortByName(int? categoryId, int? brandId, string memoryFilter, int? page = 1)
        {
            return RedirectToAction("Index", new { categoryId, brandId, memoryFilter, sortOrder = "name", page });
        }

        // Action xử lý sắp xếp theo giá
        public IActionResult SortByPrice(int? categoryId, int? brandId, string memoryFilter, int? page = 1)
        {
            return RedirectToAction("Index", new { categoryId, brandId, memoryFilter, sortOrder = "price", page });
        }

        // Action xử lý Quick View
        public IActionResult QuickView(int productId)
        {
            // Lấy thông tin sản phẩm từ database
            var product = _productService.GetProductById(productId);

            // Kiểm tra xem sản phẩm có tồn tại hay không
            if (product == null)
            {
                return NotFound();
            }

            // Truyền dữ liệu sản phẩm vào Partial View
            return PartialView("_QuickView", product);
        }
    }
}