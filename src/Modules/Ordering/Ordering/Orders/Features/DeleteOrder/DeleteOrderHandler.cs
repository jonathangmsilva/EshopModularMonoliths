using Ordering.Orders.Exceptions;

namespace Ordering.Orders.Features.DeleteOrder;

public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;

public record DeleteOrderResult( bool IsSuccess );

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty();
    }
}

public class DeleteOrderHandler(OrderingDbContext dbContext) : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.FindAsync(request.OrderId, cancellationToken);
        if (order is null)
        {
            throw new OrderNotFoundException(request.OrderId);
        }

        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteOrderResult(true);
    }
}
