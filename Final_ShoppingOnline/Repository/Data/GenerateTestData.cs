//using System.Collections.Generic;
//using Final_ShoppingOnline.Models;
//using Final_ShoppingOnline.Models.Models.ProductModel;

//namespace Final_ShoppingOnline.Repository.Data
//{
//    public static class GenerateTestData
//    {
//        public static void SeedingData(DataContext context)
//        {
//            // Danh sách các category
//            var categories = new List<CategoryModel>
//            {
//                new CategoryModel { Name = "Laptop", Description = "Danh mục Laptop" },
//                new CategoryModel { Name = "Smartphone", Description = "Danh mục Smartphone" },
//                new CategoryModel { Name = "Tablet", Description = "Danh mục Tablet" },
//                new CategoryModel { Name = "Headphone", Description = "Danh mục Headphone" },
//                new CategoryModel { Name = "Smartwatch", Description = "Danh mục Smartwatch" },
//                new CategoryModel { Name = "Accessories", Description = "Danh mục Phụ kiện" }
//            };

//            // Danh sách các brand
//            var brands = new List<BrandModel>
//            {
//                new BrandModel { Name = "Apple", LogoUrl = "/Images/Products/apple-logo.png" },
//                new BrandModel { Name = "Samsung", LogoUrl = "/Images/Products/samsung-logo.png" },
//                new BrandModel { Name = "Microsoft", LogoUrl = "/Images/Products/microsoft-logo.png" },
//                new BrandModel { Name = "Sony", LogoUrl = "/Images/Products/sony-logo.png" },
//                new BrandModel { Name = "Bose", LogoUrl = "/Images/Products/bose-logo.png" }
//            };

//            // Lưu các category vào database
//            context.Categories.AddRange(categories);
//            context.SaveChanges();

//            // Lưu các brand vào database
//            context.Brands.AddRange(brands);
//            context.SaveChanges();

//            // Danh sách các product
//            var products = new List<ProductModel>
//            {
//                new ProductModel
//                {
//                    Name = "Apple MacBook Pro 14",
//                    Slug = "apple-macbook-pro-14",
//                    ImageUrl = "/Images/Products/macbook-pro-14.jpg",
//                    HoverImageUrl = "/Images/Products/macbook-pro-14-hover.jpg",
//                    Price = 2999,
//                    SalePrice = 2599,
//                    StarRating = 4,
//                    Status = ProductStatus.Sale,
//                    Description = "Apple MacBook Pro 14 với màn hình 14 inch, chip M1 Pro/Max, RAM 16GB, SSD 512GB.",
//                    DetailedDescription = "Chi tiết sản phẩm MacBook Pro 14.",
//                    QuantityInStock = 10,
//                    IsHidden = false,
//                    IsOnSale = true,
//                    CategoryId = 1,
//                    BrandId = 1,
//                    Options = new List<ProductOption>
//                    {
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "512GB" },
//                        new ProductOption { Type = OptionTypeModel.RAM, Value = "16GB" },
//                    },
//                    Reviews = new List<ProductReview>
//                    {
//                        new ProductReview { AuthorName = "John Doe", AuthorEmail = "john.doe@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Sản phẩm tốt.", Rating = 5 },
//                        new ProductReview { AuthorName = "Jane Smith", AuthorEmail = "jane.smith@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Rất hài lòng.", Rating = 4 },
//                    },
//                    RelatedProducts = new List<ProductRelatedProductModel>
//                    {
//                        // Lưu trữ các RelatedProductId
//                    }
//                },
//                new ProductModel
//                {
//                    Name = "Apple iPhone 14 Pro Max",
//                    Slug = "apple-iphone-14-pro-max",
//                    ImageUrl = "/Images/Products/iphone-14-pro-max.jpg",
//                    HoverImageUrl = "/Images/Products/iphone-14-pro-max-hover.jpg",
//                    Price = 1299,
//                    SalePrice = 1199,
//                    StarRating = 5,
//                    Status = ProductStatus.New,
//                    Description = "Apple iPhone 14 Pro Max với màn hình 6.7 inch, chip A16 Bionic, RAM 6GB, dung lượng 128GB.",
//                    DetailedDescription = "Chi tiết sản phẩm iPhone 14 Pro Max.",
//                    QuantityInStock = 20,
//                    IsHidden = false,
//                    IsOnSale = true,
//                    CategoryId = 2,
//                    BrandId = 1,
//                    Options = new List<ProductOption>
//                    {
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "128GB" },
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "256GB" },
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "512GB" },
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "1TB" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Space Black" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Silver" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Gold" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Deep Purple" },
//                    },
//                    Reviews = new List<ProductReview>
//                    {
//                        new ProductReview { AuthorName = "Peter Pan", AuthorEmail = "peter.pan@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Thiết kế đẹp, hiệu năng tốt.", Rating = 5 },
//                        new ProductReview { AuthorName = "Wendy Darling", AuthorEmail = "wendy.darling@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Camera chụp ảnh đẹp.", Rating = 5 },
//                    },
//                    RelatedProducts = new List<ProductRelatedProductModel>
//                    {
//                        // Lưu trữ các RelatedProductId
//                    }
//                },
//                new ProductModel
//                {
//                    Name = "Samsung Galaxy S23 Ultra",
//                    Slug = "samsung-galaxy-s23-ultra",
//                    ImageUrl = "/Images/Products/galaxy-s23-ultra.jpg",
//                    HoverImageUrl = "/Images/Products/galaxy-s23-ultra-hover.jpg",
//                    Price = 1199,
//                    SalePrice = 1099,
//                    StarRating = 4,
//                    Status = ProductStatus.Sale,
//                    Description = "Samsung Galaxy S23 Ultra với màn hình 6.8 inch, chip Snapdragon 8 Gen 2, RAM 12GB, dung lượng 256GB.",
//                    DetailedDescription = "Chi tiết sản phẩm Galaxy S23 Ultra.",
//                    QuantityInStock = 15,
//                    IsHidden = false,
//                    IsOnSale = true,
//                    CategoryId = 2,
//                    BrandId = 2,
//                    Options = new List<ProductOption>
//                    {
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "256GB" },
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "512GB" },
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "1TB" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Phantom Black" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Cream" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Green" },
//                    },
//                    Reviews = new List<ProductReview>
//                    {
//                        new ProductReview { AuthorName = "Peter Pan", AuthorEmail = "peter.pan@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Thiết kế đẹp, hiệu năng tốt.", Rating = 5 },
//                        new ProductReview { AuthorName = "Wendy Darling", AuthorEmail = "wendy.darling@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Camera chụp ảnh đẹp.", Rating = 5 },
//                    },
//                    RelatedProducts = new List<ProductRelatedProductModel>
//                    {
//                        // Lưu trữ các RelatedProductId
//                    }
//                },
//                new ProductModel
//                {
//                    Name = "Microsoft Surface Laptop 5",
//                    Slug = "microsoft-surface-laptop-5",
//                    ImageUrl = "/Images/Products/surface-laptop-5.jpg",
//                    HoverImageUrl = "/Images/Products/surface-laptop-5-hover.jpg",
//                    Price = 1499,
//                    SalePrice = 1399,
//                    StarRating = 4,
//                    Status = ProductStatus.Sale,
//                    Description = "Microsoft Surface Laptop 5 với màn hình 13.5 inch, chip Intel Core i5/i7, RAM 8GB/16GB, SSD 256GB/512GB.",
//                    DetailedDescription = "Chi tiết sản phẩm Surface Laptop 5.",
//                    QuantityInStock = 12,
//                    IsHidden = false,
//                    IsOnSale = true,
//                    CategoryId = 1,
//                    BrandId = 3,
//                    Options = new List<ProductOption>
//                    {
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "256GB" },
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "512GB" },
//                        new ProductOption { Type = OptionTypeModel.RAM, Value = "8GB" },
//                        new ProductOption { Type = OptionTypeModel.RAM, Value = "16GB" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Platinum" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Sapphire" },
//                    },
//                    Reviews = new List<ProductReview>
//                    {
//                        new ProductReview { AuthorName = "Peter Pan", AuthorEmail = "peter.pan@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Thiết kế đẹp, hiệu năng tốt.", Rating = 5 },
//                        new ProductReview { AuthorName = "Wendy Darling", AuthorEmail = "wendy.darling@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Màn hình đẹp, bàn phím gõ êm.", Rating = 5 },
//                    },
//                    RelatedProducts = new List<ProductRelatedProductModel>
//                    {
//                        // Lưu trữ các RelatedProductId
//                    }
//                },
//                new ProductModel
//                {
//                    Name = "Samsung Galaxy Tab S8 Ultra",
//                    Slug = "samsung-galaxy-tab-s8-ultra",
//                    ImageUrl = "/Images/Products/galaxy-tab-s8-ultra.jpg",
//                    HoverImageUrl = "/Images/Products/galaxy-tab-s8-ultra-hover.jpg",
//                    Price = 899,
//                    SalePrice = 799,
//                    StarRating = 5,
//                    Status = ProductStatus.New,
//                    Description = "Samsung Galaxy Tab S8 Ultra với màn hình 14.6 inch, chip Snapdragon 8 Gen 1, RAM 12GB, dung lượng 256GB.",
//                    DetailedDescription = "Chi tiết sản phẩm Galaxy Tab S8 Ultra.",
//                    QuantityInStock = 18,
//                    IsHidden = false,
//                    IsOnSale = true,
//                    CategoryId = 3,
//                    BrandId = 2,
//                    Options = new List<ProductOption>
//                    {
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "256GB" },
//                        new ProductOption { Type = OptionTypeModel.ROM, Value = "512GB" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Graphite" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Silver" },
//                    },
//                    Reviews = new List<ProductReview>
//                    {
//                        new ProductReview { AuthorName = "Peter Pan", AuthorEmail = "peter.pan@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Thiết kế đẹp, hiệu năng tốt.", Rating = 5 },
//                        new ProductReview { AuthorName = "Wendy Darling", AuthorEmail = "wendy.darling@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Màn hình đẹp, âm thanh tốt.", Rating = 5 },
//                    },
//                    RelatedProducts = new List<ProductRelatedProductModel>
//                    {
//                        // Lưu trữ các RelatedProductId
//                    }
//                },
//                new ProductModel
//                {
//                    Name = "Sony WH-1000XM5",
//                    Slug = "sony-wh-1000xm5",
//                    ImageUrl = "/Images/Products/sony-wh-1000xm5.jpg",
//                    HoverImageUrl = "/Images/Products/sony-wh-1000xm5-hover.jpg",
//                    Price = 349,
//                    SalePrice = 329,
//                    StarRating = 4,
//                    Status = ProductStatus.Sale,
//                    Description = "Sony WH-1000XM5 là tai nghe không dây chống ồn cao cấp với chất lượng âm thanh tuyệt vời và khả năng khử tiếng ồn hiệu quả.",
//                    DetailedDescription = "Chi tiết sản phẩm Sony WH-1000XM5.",
//                    QuantityInStock = 15,
//                    IsHidden = false,
//                    IsOnSale = true,
//                    CategoryId = 4,
//                    BrandId = 4,
//                    Options = new List<ProductOption>
//                    {
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Black" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Silver" },
//                    },
//                    Reviews = new List<ProductReview>
//                    {
//                        new ProductReview { AuthorName = "Peter Pan", AuthorEmail = "peter.pan@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Âm thanh chất lượng, chống ồn hiệu quả.", Rating = 5 },
//                        new ProductReview { AuthorName = "Wendy Darling", AuthorEmail = "wendy.darling@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Thiết kế đẹp, đeo thoải mái.", Rating = 4 },
//                    },
//                    RelatedProducts = new List<ProductRelatedProductModel>
//                    {
//                        // Lưu trữ các RelatedProductId
//                    }
//                },
//                new ProductModel
//                {
//                    Name = "Apple Watch Series 8",
//                    Slug = "apple-watch-series-8",
//                    ImageUrl = "/Images/Products/apple-watch-series-8.jpg",
//                    HoverImageUrl = "/Images/Products/apple-watch-series-8-hover.jpg",
//                    Price = 399,
//                    SalePrice = 369,
//                    StarRating = 5,
//                    Status = ProductStatus.Sale,
//                    Description = "Apple Watch Series 8 với màn hình 41mm/45mm, chip S8 SiP, GPS/Cellular, theo dõi sức khỏe, theo dõi giấc ngủ.",
//                    DetailedDescription = "Chi tiết sản phẩm Apple Watch Series 8.",
//                    QuantityInStock = 20,
//                    IsHidden = false,
//                    IsOnSale = true,
//                    CategoryId = 5,
//                    BrandId = 1,
//                    Options = new List<ProductOption>
//                    {
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Midnight" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Starlight" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Silver" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Gold" },
//                    },
//                    Reviews = new List<ProductReview>
//                    {
//                        new ProductReview { AuthorName = "Peter Pan", AuthorEmail = "peter.pan@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Thiết kế đẹp, nhiều tính năng.", Rating = 5 },
//                        new ProductReview { AuthorName = "Wendy Darling", AuthorEmail = "wendy.darling@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Theo dõi sức khỏe tốt.", Rating = 5 },
//                    },
//                    RelatedProducts = new List<ProductRelatedProductModel>
//                    {
//                        // Lưu trữ các RelatedProductId
//                    }
//                },
//                new ProductModel
//                {
//                    Name = "Bose QuietComfort 45",
//                    Slug = "bose-quietcomfort-45",
//                    ImageUrl = "/Images/Products/bose-quietcomfort-45.jpg",
//                    HoverImageUrl = "/Images/Products/bose-quietcomfort-45-hover.jpg",
//                    Price = 329,
//                    SalePrice = 299,
//                    StarRating = 4,
//                    Status = ProductStatus.Sale,
//                    Description = "Bose QuietComfort 45 là tai nghe không dây chống ồn hiệu quả với chất lượng âm thanh tuyệt vời và thiết kế thoải mái.",
//                    DetailedDescription = "Chi tiết sản phẩm Bose QuietComfort 45.",
//                    QuantityInStock = 18,
//                    IsHidden = false,
//                    IsOnSale = true,
//                    CategoryId = 4,
//                    BrandId = 5,
//                    Options = new List<ProductOption>
//                    {
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "Black" },
//                        new ProductOption { Type = OptionTypeModel.Color, Value = "White" },
//                    },
//                    Reviews = new List<ProductReview>
//                    {
//                        new ProductReview { AuthorName = "Peter Pan", AuthorEmail = "peter.pan@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Chống ồn tốt, âm thanh hay.", Rating = 5 },
//                        new ProductReview { AuthorName = "Wendy Darling", AuthorEmail = "wendy.darling@example.com", AuthorImageUrl = "/Images/Products/user-avatar.png", Content = "Thiết kế đẹp, dễ sử dụng.", Rating = 4 },
//                    },
//                    RelatedProducts = new List<ProductRelatedProductModel>
//                    {
//                        // Lưu trữ các RelatedProductId
//                    }
//                },
//                // Tạo thêm các sản phẩm khác ...
//            };

//            // Lưu các product vào database
//            context.Products.AddRange(products);
//            context.SaveChanges();

//            // Tạo danh sách các sản phẩm liên quan
//            var relatedProducts = new List<ProductRelatedProductModel>();
//            foreach (var product in products)
//            {
//                // Lấy danh sách RelatedProductId từ thuộc tính RelatedProducts của mỗi Product
//                foreach (var relatedProductId in product.RelatedProducts.Select(rp => rp.RelatedProductId))
//                {
//                    relatedProducts.Add(new ProductRelatedProductModel
//                    {
//                        ProductId = product.Id, // Gán ProductId cho sản phẩm hiện tại
//                        RelatedProductId = relatedProductId // Gán RelatedProductId 
//                    });
//                }
//            }

//            // Lưu các sản phẩm liên quan vào database
//            context.ProductRelatedProducts.AddRange(relatedProducts);
//            context.SaveChanges();

//            // Danh sách các filter Memory
//            var memoryFilters = new List<MemoryFilterModel>
//            {
//                new MemoryFilterModel { Value = "8GB", Quantity = 8 },
//                new MemoryFilterModel { Value = "16GB", Quantity = 9 },
//                new MemoryFilterModel { Value = "32GB", Quantity = 7 },
//                new MemoryFilterModel { Value = "64GB", Quantity = 9 },
//                new MemoryFilterModel { Value = "128GB", Quantity = 12 },
//                new MemoryFilterModel { Value = "256GB", Quantity = 12 },
//                new MemoryFilterModel { Value = "512GB", Quantity = 12 },
//                new MemoryFilterModel { Value = "1TB", Quantity = 12 }
//            };

//            // ... tạo thêm các dữ liệu ảo khác 
//        }
//    }
//}