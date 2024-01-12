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
        public DbSet<AppRole>? AppRoles => this.Set<AppRole>();
        public DbSet<AppUser>? AppUsers => this.Set<AppUser>();
        public DbSet<Customer>? Customers => this.Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
