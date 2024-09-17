using Api.AutoGlass.Domain.Interfaces;
using Api.AutoGlass.Domain.Interfaces.Repositories;
using Api.AutoGlass.Infrastructure.Context;
using Api.AutoGlass.Infrastructure.Repositories;

namespace Api.AutoGlass.Infrastructure.UnitsOfWork
{
    public class MainUnitOfWork : IMainUnitOfWork
    {
        private readonly InfraContext _dbContext;
        private IProductRepository productRepository;

        public MainUnitOfWork(InfraContext context)
        {
            _dbContext = context;
        }
        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(_dbContext);

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao salvar!");
            }

            return true;
        }
    }
}
