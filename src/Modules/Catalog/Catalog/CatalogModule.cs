using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data;

namespace Catalog;
public static class CatalogModule
{
  public static IServiceCollection AddCatalogModule(this IServiceCollection services,
      IConfiguration configuration)
  {
    // Add services to the container.

    var connectionString = configuration.GetConnectionString("Database");
    services.AddDbContext<CatalogDbContext>(options =>
    {
      options.UseNpgsql(connectionString);
    });



    return services;
  }

  public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
  {
    // Configure the HTTP request pipeline.
    //app
    //    .UseApplicationServices()
    //    .UseInfrastructureServices()
    //    .UseApiServices();

    app.UseMigration<CatalogDbContext>();

    return app;
  }

}
