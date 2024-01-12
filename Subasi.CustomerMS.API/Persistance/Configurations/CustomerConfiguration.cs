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
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(75);
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);

            // Data Seed
            builder.HasData(new Customer[]
            {
                new()
                {
                    ID = new Guid("46e61ab0-946a-4e6f-901b-9cc4a919c748"),
                    FirstName = "Enes Mete",
                    LastName = "Kafali",
                    Email = "emkafali@gmail.com",
                    PhoneNumber = "553-580-9653"
                },
                new()
                {
                    ID = new Guid("58a451ed-ae3e-40fe-b118-708c0f9872f4"),
                    FirstName = "Tolga Kagan",
                    LastName = "Taskiran",
                    Email = "tktaskiran@gmail.com",
                    PhoneNumber = "546-602-3272"
                },
                new()
                {
                    ID = new Guid("7b6d363e-6fe9-4955-b8bb-36b4d535e3a6"),
                    FirstName = "Can",
                    LastName = "Temelatan",
                    Email = "temelatanc@gmail.com",
                    PhoneNumber = "533-559-0511"
                },
                new()
                {
                    ID = new Guid("29127229-8503-4e7b-b91f-249ef2a6161c"),
                    FirstName = "Yildirim",
                    LastName = "Gul",
                    Email = "yildirimgul@gmail.com",
                    PhoneNumber = "545-332-2239"
                },
                new()
                {
                    ID = new Guid("22d85348-00dc-4ec4-a5f4-e7db6dc5c652"),
                    FirstName = "Mustafa",
                    LastName = "Kafali",
                    Email = "kafali22@gmail.com",
                    PhoneNumber = "542-366-6688",
                },
                new()
                {
                    ID= new Guid("611165a4-b4c1-4ce4-aca5-2d70ee35db5a"),
                    FirstName = "Mert",
                    LastName = "Kafali",
                    Email = "mert@outlook.com",
                    PhoneNumber = "546-297-5518"
                }
            });
        }
    }
}
