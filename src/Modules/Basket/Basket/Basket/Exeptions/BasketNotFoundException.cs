using Shared.Exceptions;

namespace Basket.Basket.Exeptions;

public class BasketNotFoundException(string userName)
    : NotFoundException("ShoppingCart", userName)
{
}