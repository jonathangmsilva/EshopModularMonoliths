namespace Basket.Basket.Features.DeleteBasket;

public record DeleteBasketResponse(bool IsSuccess);

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(userName));
                var response = result.Adapt<DeleteBasketResponse>();
                return Results.Ok(response);
            }).Produces<DeleteBasketResponse>()
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Deletes a basket")
            .WithDescription("Deletes a basket")
            .RequireAuthorization();
    }
}
