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
            builder.Property(x => x.District).IsRequired();
            builder.Property(x => x.Province).IsRequired();
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
                    ID = 1,
                    AddressLine = "Yavrukus St. No:19/1",
                    District = "Sisli",
                    Province = "Istanbul",
                    CustomerID = 1,
                    AddressType = AddressType.Home,
                },
                new()
                {
                    ID = 2,
                    AddressLine = "Lalegul St. No:5",
                    District = "Kagithane",
                    Province = "Istanbul",
                    CustomerID = 1,
                    AddressType = AddressType.Office,
                },
                new()
                {
                    ID = 3,
                    AddressLine = "Ali Riza Efendi St. No:22",
                    District = "Kesan",
                    Province = "Edirne",
                    CustomerID = 2,
                    AddressType = AddressType.Home,
                },
                new()
                {
                    ID = 4,
                    AddressLine = "Seher St. No:16/60",
                    District = "Maltepe",
                    Province = "Istanbul",
                    CustomerID = 6,
                    AddressType = AddressType.Home,
                }
            });
        }
    }
}
