using Microsoft.EntityFrameworkCore;
using payback.Server.Models;

namespace payback.Server.DB
{
    public class PaybackContext : DbContext
    {
        public PaybackContext(DbContextOptions<PaybackContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.Amount)
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Amount)
                      .HasColumnType("decimal(18,2)");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
