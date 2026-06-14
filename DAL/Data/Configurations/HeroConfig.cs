using DAL.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data.Configurations
{
    internal class HeroConfig:IEntityTypeConfiguration<HeroSection>
    {
        public void Configure(EntityTypeBuilder<HeroSection> builder)
        {
            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Description)
                           .IsRequired();

            builder.Property(e => e.ImageUrl)
                  .IsRequired()
                  .HasMaxLength(500);

        }
    }
}
