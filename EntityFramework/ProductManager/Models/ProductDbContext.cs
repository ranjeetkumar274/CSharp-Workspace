using Microsoft.EntityFrameworkCore;

namespace ProductManager.Models
{
    public class ProductDbContext: DbContext
    {
        
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {}

    public DbSet<Product> Products{get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(e =>
            {
                // Primary Key
                e.HasKey(et => et.ProductId);
                e.ToTable("Products");
                e.Property(et => et.Name).IsRequired().HasMaxLength(150);
                e.Property(et => et.Price).IsRequired();
            });
        }
    }
}