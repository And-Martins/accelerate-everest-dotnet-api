using CustomerRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegister.Data
{
    public class RegisterDBContext : DbContext
    {
        public RegisterDBContext(DbContextOptions<RegisterDBContext> options) 
            : base(options)
        {

        }

        public DbSet<CustomerEntity> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
