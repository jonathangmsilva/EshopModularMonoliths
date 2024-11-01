﻿namespace Catalog.Products.Features.GetProductByCategory;

public record GetProductByCategoryResponse(IEnumerable<ProductDto> Products);

public class GetProductByCategory : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));

                var resposne = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(resposne);
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get products by Category")
            .WithDescription("Get products by Category");
    }
}