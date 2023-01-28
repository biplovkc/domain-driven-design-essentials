namespace Biplov.DDD.Essentials;

/// <summary>
/// Base class for aggregate roots
/// </summary>
public class Entity
{
    public string Id { get; }

    protected Entity()
    {
        Id = $"ent_{Guid.NewGuid():N}";
    }

    protected Entity(string id) : this()
    {
        Id = id;
    }

    private readonly List<DomainEvent> _domainEvents = new();
    public IReadOnlyList<DomainEvent>? DomainEvents => _domainEvents?.ToList();

    protected void RaiseDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();

    public bool IsTransient() => string.IsNullOrWhiteSpace(Id);

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (Id == string.Empty || other.Id == string.Empty)
            return false;

        return Id == other.Id;
    }

    public static bool operator ==(Entity? a, Entity? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b) => !(a == b);

    public override int GetHashCode() => (GetType() + Id).GetHashCode();
}