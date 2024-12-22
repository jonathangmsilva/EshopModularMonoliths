namespace Basket.Basket.Features.GetBasket;

public record GetBasketResponse(ShoppingCartDto ShoppingCart);

public class GetBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var query = new GetBasketQuery(userName);
                var result = await sender.Send(query);

                var response = result.Adapt<GetBasketResponse>();
                return Results.Ok(response);
            }).Produces<GetBasketResponse>()
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Get the current basket for a user")
            .WithDescription("Returns the current basket for a user")
            .RequireAuthorization();
    }
}
