﻿namespace Catalog.Products.Features.GetProducts;

public record GetProductsResponse(IEnumerable<ProductDto> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).Produces<GetProductsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get products");
    }
}