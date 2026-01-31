using Microsoft.EntityFrameworkCore;

namespace GymPass.Models
{
    public class PassDbContext : DbContext
    {
        
        public PassDbContext(DbContextOptions<PassDbContext> ops):base(ops){}

        public DbSet<Pass> Passes{get; set;}

        protected override void OnModelCreating(ModelBuilder build)
        {
            base.OnModelCreating(build);
            build.Entity<Pass>(et =>
            {
                et.HasKey(e => e.PassId);
                et.ToTable("Passes");
                et.Property(e => e.Name).IsRequired().HasMaxLength(150);
                et.Property(e => e.PassNumber).IsRequired().HasMaxLength(150);
                et.Property(e => e.Holder).IsRequired().HasMaxLength(150);
            });
        }
    }
}

