using System.Security.Claims;

namespace Basket.Basket.Features.CreateBasket;

public record CreateBasketRequest(ShoppingCartDto ShoppingCart);

public record CreateBasketResponse(Guid Id);

public class CreateBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (CreateBasketRequest request, ISender sender, ClaimsPrincipal user) =>
            {
                var username = user.Identity!.Name;
                var updatedShoppingCart = request.ShoppingCart with { UserName = username };

                var command = updatedShoppingCart.Adapt<CreateBasketCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateBasketResponse>();

                return Results.Created($"/basket/{response.Id}", response);
            })
            .Produces<CreateBasketResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Create Basket")
            .WithDescription("Create a new basket")
            .RequireAuthorization();
    }
}
