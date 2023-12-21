using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Persistance.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Entity Configurations
            builder.Property(x => x.ID).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();

            // Data Seed
            builder.HasData(new Customer[]
            {
                new()
                {
                    ID = 1,
                    FirstName = "Enes Mete",
                    LastName = "Kafali",
                    Email = "emkafali@gmail.com",
                    PhoneNumber = "553-580-9653"
                },
                new()
                {
                    ID = 2,
                    FirstName = "Tolga Kagan",
                    LastName = "Taskiran",
                    Email = "tktaskiran@gmail.com",
                    PhoneNumber = "546-602-3272"
                },
                new()
                {
                    ID = 3,
                    FirstName = "Can",
                    LastName = "Temelatan",
                    Email = "temelatanc@gmail.com",
                    PhoneNumber = "533-559-0511"
                },
                new()
                {
                    ID = 4,
                    FirstName = "Yildirim",
                    LastName = "Gul",
                    Email = "yildirimgul@gmail.com",
                    PhoneNumber = "545-332-2239"
                },
                new()
                {
                    ID = 5,
                    FirstName = "Mustafa",
                    LastName = "Kafali",
                    Email = "kafali22@gmail.com",
                    PhoneNumber = "542-366-6688",
                },
                new()
                {
                    ID= 6,
                    FirstName = "Mert",
                    LastName = "Kafali",
                    Email = "mert@outlook.com",
                    PhoneNumber = "546-297-5518"
                }
            });
        }
    }
}
