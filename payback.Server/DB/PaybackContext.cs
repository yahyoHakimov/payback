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

    }
}
