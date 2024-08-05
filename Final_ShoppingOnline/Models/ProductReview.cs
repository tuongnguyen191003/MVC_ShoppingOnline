namespace Final_ShoppingOnline.Models.Models.ProductModel
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; } // Navigation property
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorImageUrl { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
