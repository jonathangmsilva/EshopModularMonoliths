using Shared.CQRS;

namespace Catalog.Products.Features.DeleteProduct;

public record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FindAsync([request.ProductId], cancellationToken);
        if (product is null)
            throw new InvalidOperationException($"Product with id {request.ProductId} was not found");

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}