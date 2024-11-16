namespace Basket.Basket.Dtos;

public record ShoopingCartItemDto(
    Guid Id,
    Guid ShoppingCartId,
    Guid ProductId,
    int Quantity,
    string Color,
    decimal Price,
    string ProductName
);