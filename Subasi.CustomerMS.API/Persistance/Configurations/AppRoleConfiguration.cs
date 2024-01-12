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
                    ID = new Guid("b1803d37-f260-4135-afb2-b44ae26c58ed"),
                    Definition = "Admin"
                },
                new()
                {
                    ID = new Guid("0910659f-670a-47d2-aa00-6a343dbaae48"),
                    Definition = "Member"
                }
            ]);
        }
    }
}
