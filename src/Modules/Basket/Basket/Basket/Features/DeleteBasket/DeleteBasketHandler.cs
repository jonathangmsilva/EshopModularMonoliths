namespace Basket.Basket.Features.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsDeleted);

public class DeleteBasketHandler(BasketDbContext dbContext)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await dbContext.ShoppingCarts
            .SingleOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);

        if (basket == null) throw new BasketNotFoundException(request.UserName);

        dbContext.ShoppingCarts.Remove(basket);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteBasketResult(true);
    }
}