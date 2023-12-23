using Microsoft.EntityFrameworkCore;
using Subasi.CustomerMS.API.Core.Domain.Concrete;
using Subasi.CustomerMS.API.Persistance.Configurations;

namespace Subasi.CustomerMS.API.Persistance.Context
{
    public class SubasiCustomerMSDbContext : DbContext
    {
        public SubasiCustomerMSDbContext(DbContextOptions<SubasiCustomerMSDbContext> options) : base(options)
        {
        }

        public DbSet<Address>? Addresses => this.Set<Address>();
        public DbSet<Customer>?  Customers => this.Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
