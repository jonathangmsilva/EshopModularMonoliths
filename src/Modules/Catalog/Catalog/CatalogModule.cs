using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog;

public static class CatalogModule
{
  public static IServiceCollection AddCatalogModule(this IServiceCollection services,
    IConfiguration configuration)
  {
    //services.AddAutoMapper(typeof(CatalogModule));
    //services.AddMediatR(typeof(CatalogModule));
    //services.AddValidatorsFromAssembly(typeof(CatalogModule).Assembly);
    //services.AddDbContext<CatalogDbContext>(options =>
    //{
    //  options.UseSqlServer("Server=.;Initial Catalog=MyStore_Catalog;Integrated Security=true");
    //});

    //services.AddScoped<IProductRepository, ProductRepository>();
    //services.AddScoped<IProductService, ProductService>();

    return services;
  }

  public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
  {
    //var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
    //using var scope = scopeFactory.CreateScope();
    //var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
    //dbContext.Database.EnsureCreated();
    return app;
  }

}
