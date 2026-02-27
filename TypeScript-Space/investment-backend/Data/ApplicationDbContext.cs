using Microsoft.EntityFrameworkCore;
using InvestmentBackend.Models;

namespace InvestmentBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
 
        public DbSet<Investment> Investments { get; set; }
    }
}