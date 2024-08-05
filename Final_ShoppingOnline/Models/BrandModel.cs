
using System.ComponentModel.DataAnnotations;
namespace Final_ShoppingOnline.Models.Models.ProductModel
{
    public class BrandModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên thương hiệu không được để trống.")]
        [MaxLength(255, ErrorMessage = "Tên thương hiệu không được vượt quá 255 ký tự.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "URL logo không được để trống.")]
        [Url(ErrorMessage = "URL logo không hợp lệ.")]
        public string LogoUrl { get; set; } // URL of brand logo

        public ICollection<ProductModel> Products { get; set; } // Navigation property
    }
}
