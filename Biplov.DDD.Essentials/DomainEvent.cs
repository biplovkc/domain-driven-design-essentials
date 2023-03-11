namespace Biplov.DDD.Essentials;

/// <summary>
/// Base class for domain event
/// </summary>
public record DomainEvent
{
    /// <summary>
    /// Initialized DomainEvent object with default values
    /// Id follows pattern ${dme_{Guid.NewGuid():N}}
    /// CreationDate is utc date time
    /// </summary>
    public DomainEvent()
    {
        Id = $"dme_{Guid.NewGuid():N}";
        CreationDate = DateTime.UtcNow;
    }

    /// <summary>
    /// Initializes DomainEvent with given DateTime
    /// </summary>
    /// <param name="id">domain event id</param>
    /// <param name="creationDate">domain event creation date</param>
    /// <exception cref="ArgumentException"></exception>
    public DomainEvent(string id, DateTime creationDate) : this()
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException(nameof(id));

        Id = id;
        CreationDate = creationDate;
    }

    /// <summary>
    /// Domain event Id
    /// Default value is $"dme_{Guid.NewGuid():N}"
    /// </summary>
    public string Id { get; init; }

    /// <summary>
    /// Domain event creation date time
    /// Default value is utc date time
    /// </summary>
    public DateTime CreationDate { get; init; }
}
