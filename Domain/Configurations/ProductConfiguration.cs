using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired(false);
            builder.Property(m=>m.SoftDelete).IsRequired().HasDefaultValue(false);
            builder.Property(m=>m.Description).HasMaxLength(50).IsRequired(false);
            builder.Property(m => m.Price).IsRequired().HasConversion(v => Math.Round(v, 2), v => v);
            builder.Property(m => m.Image).IsRequired();


        }
    }

}
