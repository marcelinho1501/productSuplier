using Api.AutoGlass.Domain.Entities;

namespace Api.AutoGlass.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(int? code);
        Task AddAsync(Product product);
        void Update(Product product);
        Task<bool> Remove(int code);
        IQueryable<Product> Query();
    }
}
