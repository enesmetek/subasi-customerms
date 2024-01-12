using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subasi.CustomerMS.API.Core.Domain.Concrete;
using Subasi.CustomerMS.API.Core.Domain.Enums;

namespace Subasi.CustomerMS.API.Persistance.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Entity Configurations
            builder.Property(x => x.AddressLine).IsRequired();
            builder.Property(x => x.AddressLine).HasMaxLength(100);
            builder.Property(x => x.District).IsRequired();
            builder.Property(x => x.District).HasMaxLength(100);
            builder.Property(x => x.Province).IsRequired();
            builder.Property(x => x.Province).HasMaxLength(100);
            builder.Property(x => x.CustomerID).IsRequired();

            // Enum Conversion
            builder.Property(x => x.AddressType).HasConversion(y => y.ToString(), y => Enum.Parse<AddressType>(y));

            // Relations
            builder.HasOne(x => x.Customer).WithMany(x => x.Addresses).HasForeignKey(x => x.CustomerID);

            // Data Seed
            builder.HasData(new Address[]
            {
                new()
                {
                    ID = new Guid("ffab8c77-239f-4d24-ba12-5d9aca99dbb4"),
                    AddressLine = "Yavrukus St. No:19/1",
                    District = "Sisli",
                    Province = "Istanbul",
                    CustomerID = new Guid("46e61ab0-946a-4e6f-901b-9cc4a919c748"),
                    AddressType = AddressType.Home,
                },
                new()
                {
                    ID = new Guid("c1b4eeb9-dfec-4e38-b0e8-311db9edfec4"),
                    AddressLine = "Lalegul St. No:5",
                    District = "Kagithane",
                    Province = "Istanbul",
                    CustomerID = new Guid("46e61ab0-946a-4e6f-901b-9cc4a919c748"),
                    AddressType = AddressType.Office,
                },
                new()
                {
                    ID = new Guid("1f4cba7e-dd74-4e76-9a92-ca766a4b70d7"),
                    AddressLine = "Ali Riza Efendi St. No:22",
                    District = "Kesan",
                    Province = "Edirne",
                    CustomerID = new Guid("58a451ed-ae3e-40fe-b118-708c0f9872f4"),
                    AddressType = AddressType.Home,
                },
                new()
                {
                    ID = new Guid("7aff0742-36d6-4630-b1b4-68538ad56d64"),
                    AddressLine = "Seher St. No:16/60",
                    District = "Maltepe",
                    Province = "Istanbul",
                    CustomerID = new Guid("611165a4-b4c1-4ce4-aca5-2d70ee35db5a"),
                    AddressType = AddressType.Home,
                }
            });
        }
    }
}
