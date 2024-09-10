using MediatR;

namespace Shared.Primitives;
public interface IDomainEvent : INotification
{
  Guid EventId => Guid.NewGuid();
  DateTime OccurredOn => DateTime.UtcNow;
  public string EventType => GetType().AssemblyQualifiedName;
}
