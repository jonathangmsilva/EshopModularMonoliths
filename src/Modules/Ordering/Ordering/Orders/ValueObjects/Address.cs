namespace Ordering.Orders.ValueObjects;

public class Address
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string AddressLine { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    protected Address(){}

    private Address(string firstName, string lastName, string emailAddress, string addressLine, string country,
        string state, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;

    }

    public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country,
        string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrEmpty(emailAddress, nameof(emailAddress));
        ArgumentException.ThrowIfNullOrEmpty(addressLine);

        return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }
}
