using Api.AutoGlass.Domain.Command;
using Api.AutoGlass.Domain.Interfaces;
using Api.AutoGlass.Domain.Services;
using Api.AutoGlass.Domain.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Api.AutoGlass.Domain
{
    public static class ServiceCollection
    {
        public static void AddDomainServiceDependency(this IServiceCollection services)
        {
            services.AddTransient<IProdutService, ProductService>();
        }
        public static void AddFluentValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<InsertProductCommand>, ProductRequestValidator>();
            services.AddScoped<IValidator<UpdateProductCommand>, UpdateRequestValidator>();
        }
    }
}
