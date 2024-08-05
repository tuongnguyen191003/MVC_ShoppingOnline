using Final_ShoppingOnline.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_ShoppingOnline.Models.Models.ProductModel
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [MaxLength(255, ErrorMessage = "Tên sản phẩm không được vượt quá 255 ký tự.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Slug không được để trống.")]
        [MaxLength(255, ErrorMessage = "Slug không được vượt quá 255 ký tự.")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống.")]
        public string HoverImageUrl { get; set; }

        [FileExtension("jpg", "png", "jpeg", "gif", "bmp", "tiff", "webp")]
        [NotMapped]
        public IFormFile? ImageUpload { get; set; }
        [FileExtension("jpg", "png", "jpeg", "gif", "bmp", "tiff", "webp")]
        [NotMapped]
        public IFormFile? HoverImageUpload { get; set; }

        [Required(ErrorMessage = "Giá bán không được để trống.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải là số dương.")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi phải là số dương.")]
        public decimal SalePrice { get; set; }

        [Required(ErrorMessage = "Số sao đánh giá không được để trống.")]
        [Range(1, 5, ErrorMessage = "Số sao đánh giá phải từ 1 đến 5.")]
        public int StarRating { get; set; }

        [Required(ErrorMessage = "Trạng thái sản phẩm không được để trống.")]
        public ProductStatus Status { get; set; }

        [MaxLength(500, ErrorMessage = "Mô tả ngắn gọn không được vượt quá 500 ký tự.")]
        public string Description { get; set; }

        [MaxLength(1000, ErrorMessage = "Mô tả chi tiết không được vượt quá 1000 ký tự.")]
        public string DetailedDescription { get; set; }

        [Required(ErrorMessage = "Số lượng tồn kho không được để trống.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho phải là số nguyên dương.")]
        public int QuantityInStock { get; set; }

        public bool IsHidden { get; set; }
        public bool IsOnSale { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Thương hiệu không được để trống.")]
        public int BrandId { get; set; }

        public ICollection<ProductOption> Options { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public ICollection<ProductRelatedProductModel> RelatedProducts { get; set; }

        // Navigation properties
        public CategoryModel Category { get; set; } // Navigation property to Category
        public BrandModel Brand { get; set; } // Navigation property to Brand
    }
}
