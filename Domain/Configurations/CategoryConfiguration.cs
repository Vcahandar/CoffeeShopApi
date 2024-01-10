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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired(false);
            builder.Property(m=>m.SoftDelete).IsRequired().HasDefaultValue(false);
            builder.Property(m=>m.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
        }
    }

}
