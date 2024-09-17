using Api.AutoGlass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.AutoGlass.Infrastructure.Context.TypeConfigurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status);
            builder.Property(x => x.DateManufacturing);
            builder.Property(x => x.DateValidate);
            builder.Property(x => x.SupplierCode);
            builder.Property(x => x.SupplierDescription);
            builder.Property(x => x.Cnpj);
        }
    }
}
