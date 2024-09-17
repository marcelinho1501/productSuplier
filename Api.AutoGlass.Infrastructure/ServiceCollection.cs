using Api.AutoGlass.Domain.Interfaces;
using Api.AutoGlass.Infrastructure.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Api.AutoGlass.Infrastructure
{
    public static class ServiceCollection
    {
        public static void AddInfraDataSqlDependency(this IServiceCollection services)
        {
            services.AddScoped<IMainUnitOfWork, MainUnitOfWork>();
        }
    }
}
