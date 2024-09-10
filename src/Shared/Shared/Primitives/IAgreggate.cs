namespace Shared.Primitives;
public interface IAgreggate : IEntity
{
  IReadOnlyList<IDomainEvent> DomainEvents { get; }
  IDomainEvent[] ClearDomainEvents();
}

public interface IAgreggate<T> : IAgreggate, IEntity<T>
{

}
