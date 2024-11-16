namespace Basket.Basket.Features.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCartDto ShoppingCart);

public class GetBasketHandler(BasketDbContext dbContext) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await dbContext.ShoppingCarts
            .AsNoTracking()
            .Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);

        if (basket is null) throw new BasketNotFoundException(request.UserName);

        var basketDto = basket.Adapt<ShoppingCartDto>();
        return new GetBasketResult(basketDto);
    }
}