using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using TektonLabs.HxArq.Application.Loggin;
using TektonLabs.HxArq.Application.Validators;
using TektonLabs.HxArq.Application.Commands;
using TektonLabs.HxArq.Application.Handlers;
using TektonLabs.HxArq.Domain.Interfaces;
using TektonLabs.HxArq.Infrastructure.Cache;
using TektonLabs.HxArq.Infrastructure.Repositories;
using TektonLabs.HxArq.Infrastructure.Configurations;
using TektonLabs.HxArq.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hexagonal API", Version = "v1" });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateProductCommandHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateProductCommandHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetProductByIdQueryHandler>());

builder.Services.AddTransient<IProductRepository, InMemoryProductRepository>();
builder.Services.AddTransient<IValidator<CreateProductCommand>, CreateProductValidator>();
builder.Services.AddTransient<IValidator<UpdateProductCommand>, UpdateProductValidator>();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddSingleton<ProductStatusCache>();
builder.Services.Configure<DiscountServiceSettings>(builder.Configuration.GetSection("DiscountService"));
builder.Services.AddTransient<DiscountService>();
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hexagonal API V1"));
}

// Configurar el middleware de la aplicación
app.MapGet("/", (IOptions<DiscountServiceSettings> options) =>
{
    var settings = options.Value;
    return $"Service URL: {settings.ServiceUrl}";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.UseMiddleware<RequestLogger>();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
