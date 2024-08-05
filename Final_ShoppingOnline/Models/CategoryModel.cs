using System.ComponentModel.DataAnnotations;

namespace Final_ShoppingOnline.Models.Models.ProductModel
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống.")]
        [MaxLength(255, ErrorMessage = "Tên danh mục không được vượt quá 255 ký tự.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Mô tả danh mục không được vượt quá 500 ký tự.")]
        public string Description { get; set; }

        public ICollection<ProductModel> Products { get; set; } // Navigation property
    }
}
