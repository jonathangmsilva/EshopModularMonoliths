using Catalog.Products.Features.GetProducts;

namespace Catalog.Products.Features.GetProductById;

public record GetProductByIdResponse(ProductDto Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id:guid}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(Id));

            var response = result.Adapt<GetProductsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get product by id")
        .WithDescription("Get product by id");
    }
}