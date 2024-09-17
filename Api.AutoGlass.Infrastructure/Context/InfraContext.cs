using Api.AutoGlass.Domain.Entities;
using Api.AutoGlass.Infrastructure.Context.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Api.AutoGlass.Infrastructure.Context
{
    public class InfraContext : DbContext
    {
        public InfraContext(DbContextOptions<InfraContext> options) : base(options)
        {
        }
        public DbSet<Product> product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
        }
    }
}
