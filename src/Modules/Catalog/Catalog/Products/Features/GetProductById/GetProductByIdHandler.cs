namespace Catalog.Products.Features.GetProductById;

public record GetProductByIdResult(ProductDto Product);

public record GetProductByIdQuery(Guid ProductId) : IQuery<GetProductByIdResult>;

public class GetProductByIdHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

        if (product is null)
            throw new Exception($"Product with id: {request.ProductId} was not found");

        var productDto = product.Adapt<ProductDto>();

        return new GetProductByIdResult(productDto);
    }
}