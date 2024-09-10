namespace Shared.Primitives;
public abstract class Agreggate<TId> : Entity<TId>, IAgreggate<TId>
{
  private readonly List<IDomainEvent> _domainEvents = new();
  public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

  protected void AddDomainEvent(IDomainEvent domainEvent)
  {
    _domainEvents.Add(domainEvent);
  }

  public IDomainEvent[] ClearDomainEvents()
  {
    IDomainEvent[] domainEvents = _domainEvents.ToArray();
    _domainEvents.Clear();
    return domainEvents;
  }
}
