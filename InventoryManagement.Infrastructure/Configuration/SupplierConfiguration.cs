using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        { 
            builder.HasKey(p => p.Id);
            // Configuring Address as an owned entity type of Order
            builder.OwnsOne(o => o.address, sa =>
            {
                // Configure each property if needed
                sa.Property(p => p.Street).HasColumnName("Street");
                sa.Property(p => p.City).HasColumnName("City");
                sa.Property(p => p.State).HasColumnName("State");
                sa.Property(p => p.ZipCode).HasColumnName("ZipCode");
            });
        }
    }
}
