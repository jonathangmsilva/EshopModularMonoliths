using Microsoft.EntityFrameworkCore;
using Ordering.Orders.Dtos;
using Ordering.Orders.Exceptions;

namespace Ordering.Orders.Features.GetOrderById;

public record GetOrderByIdQuery(Guid OrderId) : IQuery<GetOrderByIdResult>;

public record GetOrderByIdResult
{
    public OrderDto Order { get; init; } = default!;
}

public class GetOrderByIdHandler(OrderingDbContext dbContext) : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResult>
{
    public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Items)
            .FirstOrDefaultAsync(fd => fd.Id == request.OrderId);

        if (order is null)
        {
            throw new OrderNotFoundException(request.OrderId);
        }

        var orderDto = order.Adapt<OrderDto>();
        return new GetOrderByIdResult{ Order = orderDto };
    }
}
