using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.SellerAgg
{
    internal partial class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "seller");
    
            builder.Property(b => b.ShopName)
                .IsRequired();

            builder.OwnsMany(b => b.Inventories, option =>
            {
                option.ToTable("Inventories", "seller");
                option.HasKey(b => b.Id);
                option.HasIndex(b => b.ProductId);
                option.HasIndex(b => b.SellerId);

            });
        }
    }
}
