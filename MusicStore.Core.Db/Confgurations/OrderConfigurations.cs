using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Shared.Models;

namespace MusicStore.Core.Db.Confgurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c=> c.Id);
            builder.Property(c=> c.ProductId).IsRequired();
            builder.Property(c => c.CustomerId).IsRequired();
            builder.Property(c => c.EmployeeId).IsRequired();
            builder.Property(c => c.TotalPrice);
            builder.Property(c => c.PurchaseDate);
        }
    }
}
