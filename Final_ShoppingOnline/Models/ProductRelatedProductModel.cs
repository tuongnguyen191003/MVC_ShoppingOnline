namespace Final_ShoppingOnline.Models.Models.ProductModel
{
    public class ProductRelatedProductModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int RelatedProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
