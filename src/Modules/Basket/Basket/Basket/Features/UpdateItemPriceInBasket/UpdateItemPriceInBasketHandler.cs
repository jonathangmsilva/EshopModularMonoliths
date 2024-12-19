namespace Basket.Basket.Features.UpdateItemPriceInBasket;

public record UpdateItemPriceInBasketCommand(Guid ProductId, decimal Price)
    : ICommand<UpdateItemPriceInBasketResult>;

public record UpdateItemPriceInBasketResult(bool Success);

public class UpdateItemPriceInBasketCommandValidator : AbstractValidator<UpdateItemPriceInBasketCommand>
{
    public UpdateItemPriceInBasketCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}


public class UpdateItemPriceInBasketHandler(BasketDbContext dbContext)
    : ICommandHandler<UpdateItemPriceInBasketCommand, UpdateItemPriceInBasketResult>
{
    public async Task<UpdateItemPriceInBasketResult> Handle(UpdateItemPriceInBasketCommand request, CancellationToken cancellationToken)
    {
        var itemsToUpdate = await dbContext.ShoppingCartItems
            .Where(x => x.ProductId == request.ProductId)
            .ToListAsync(cancellationToken);

        if (!itemsToUpdate.Any())
        {
            return new UpdateItemPriceInBasketResult(false);
        }

        foreach (var item in itemsToUpdate)
        {
            item.UpdatePrice(request.Price);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateItemPriceInBasketResult(true);
    }
}
