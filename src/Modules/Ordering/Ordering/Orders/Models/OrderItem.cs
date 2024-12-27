﻿namespace Ordering.Orders.Models;

public class OrderItem: Entity<Guid>
{
    internal OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
}
