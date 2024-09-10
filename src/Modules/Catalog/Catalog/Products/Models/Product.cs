namespace Catalog.Products.Models;

public class Product : Agreggate<Guid>
{
  public string Name { get; private set; } = default!;
  public List<string> Category { get; private set; } = new();
  public string Description { get; private set; } = default!;
  public string ImageFile { get; private set; } = default!;
  public decimal Price { get; private set; }


  public static Product Create(Guid Id, string name, List<string> category, string description, decimal price)
  {
    ArgumentException.ThrowIfNullOrEmpty(name);
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

    var product = new Product
    {
      Id = Id,
      Name = name,
      Category = category,
      Description = description,
      Price = price
    };

    product.AddDomainEvent(new ProductCreatedEvent(product));
    return product;
  }

  public void Update(string name, List<string> category, string description, string imageFile, decimal price)
  {
    ArgumentException.ThrowIfNullOrEmpty(name);
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);



    Name = name;
    Category = category;
    Description = description;
    ImageFile = imageFile;

    if (price != Price)
    {
      Price = price;
      AddDomainEvent(new ProductPriceChangedEvent(this));
    }

  }

}
