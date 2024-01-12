using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Persistance.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            // Data Seed
            builder.HasData(
            [
                new()
                {
                    ID = 1,
                    Definition = "Admin"
                },
                new()
                {
                    ID = 2,
                    Definition = "Member"
                }
            ]);
        }
    }
}
