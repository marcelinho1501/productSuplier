using Api.AutoGlass.Domain.Entities;
using Api.AutoGlass.Domain.Interfaces.Repositories;
using Api.AutoGlass.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.AutoGlass.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly InfraContext _dbContext;
        public ProductRepository(InfraContext context)
        {
            _dbContext = context;
        }
        public async Task<Product> GetById(int? code)
        {
            return await _dbContext.product.FirstOrDefaultAsync(x => x.Code == code);
        }
        public async Task<Product> Add(Product product)
        {
            await _dbContext.product.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }
        public async Task<bool> Remove(int code)
        {
            Product productModel = await GetById(code);
            if (productModel == null)
            {
                throw new Exception($"Produto {code} não encontrado!");
                return false;
            }
            _dbContext.product.Remove(productModel);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<Product> Query()
        {
            return _dbContext.product.AsQueryable();
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.product.AddAsync(product);
        }

        public void Update(Product product)
        {
            _dbContext.product.Update(product);
        }
    }
}
