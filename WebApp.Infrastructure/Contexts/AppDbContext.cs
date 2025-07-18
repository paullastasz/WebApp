using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //strategia tworzenia kluczy
            modelBuilder.UseIdentityAlwaysColumns();

            //klucze podstawowe
            modelBuilder.Entity<Transaction>()
                .HasKey(e => e.ID);

        }
    }
}
