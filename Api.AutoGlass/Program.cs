using Api.AutoGlass.Domain;
using Api.AutoGlass.Domain.Interfaces.Repositories;
using Api.AutoGlass.Domain.Validators;
using Api.AutoGlass.Infrastructure;
using Api.AutoGlass.Infrastructure.Context;
using Api.AutoGlass.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfraDataSqlDependency();
builder.Services.AddDomainServiceDependency();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidators();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Api.AutoGlass.Domain")));

var connectionString = builder.Configuration.GetConnectionString("PostNpgConnection");
builder.Services.AddDbContext<InfraContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
