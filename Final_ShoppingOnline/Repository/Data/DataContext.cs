using Final_ShoppingOnline.Models.Models.ProductModel;
using Microsoft.EntityFrameworkCore;

namespace Final_ShoppingOnline.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<ProductRelatedProductModel> ProductRelatedProducts { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId);

            modelBuilder.Entity<ProductOption>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Options)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<ProductReview>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<ProductRelatedProductModel>()
                .HasOne(rp => rp.Product)
                .WithMany(p => p.RelatedProducts)
                .HasForeignKey(rp => rp.ProductId);
        }
    }
}
