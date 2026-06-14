using DAL.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data.Configurations
{
    internal class ContactConfg : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);


            builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(150);

            builder.Property(c => c.Message)
            .IsRequired()
            .HasColumnType("nvarchar(max)");


        }
    }
}
