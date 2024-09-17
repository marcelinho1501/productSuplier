using Api.AutoGlass.Domain.Interfaces.Repositories;

namespace Api.AutoGlass.Domain.Interfaces
{
    public interface IMainUnitOfWork
    {
        Task<bool> CommitAsync();
        IProductRepository ProductRepository { get; }
    }
}
