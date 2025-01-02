namespace Basket.Basket.Models;

public class OutboxMessage : Entity<Guid>
{
    public string Type { get; set; }
    public string Content { get; set; }
    public DateTime OccurredOn { get; set; }
    public DateTime? ProcessedOn { get; set; }
}
