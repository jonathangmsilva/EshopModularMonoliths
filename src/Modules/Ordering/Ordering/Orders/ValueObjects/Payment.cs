﻿namespace Ordering.Orders.ValueObjects;

public record Payment
{
    public string CardName { get; init; }
    public string CardNumber { get; init; }
    public string Expiration { get; init; }
    public string CVV { get; init; }
    public int PaymentMethod { get; init; }

    protected Payment()
    {
    }

    private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName, nameof(cardName));
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber, nameof(cardNumber));
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv, nameof(cvv));

        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }
}