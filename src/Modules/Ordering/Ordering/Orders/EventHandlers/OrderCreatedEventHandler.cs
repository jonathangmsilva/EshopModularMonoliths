﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace Ordering.Orders.EventHandlers;

public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
: INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Order created");
        return Task.CompletedTask;
    }
}
