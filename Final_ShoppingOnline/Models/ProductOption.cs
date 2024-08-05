namespace Final_ShoppingOnline.Models.Models.ProductModel
{
    public class ProductOption
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; } // Navigation property
        public OptionTypeModel Type { get; set; }
        public string Value { get; set; }
    }
}
