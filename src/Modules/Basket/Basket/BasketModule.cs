using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket;

public static class BasketModule
{
  public static IServiceCollection AddBasketModule(this IServiceCollection services,
    IConfiguration configuration)
  {
    //services.AddAutoMapper(typeof(BasketModule));
    //services.AddMediatR(typeof(BasketModule));
    //services.AddValidatorsFromAssembly(typeof(BasketModule).Assembly);
    //services.AddDbContext<BasketDbContext>(options =>
    //{
    //  options.UseSqlServer("Server=.;Initial Catalog=MyStore_Basket;Integrated Security=true");
    //});

    //services.AddScoped<IBasketRepository, BasketRepository>();
    //services.AddScoped<IBasketService, BasketService>();

    return services;
  }


  public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app)
  {
    //var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
    //using var scope = scopeFactory.CreateScope();
    //var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
    //dbContext.Database.EnsureCreated();
    return app;
  }

}
