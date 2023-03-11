namespace Biplov.DDD.Essentials;

public record IntegrationEvent
{        
    public IntegrationEvent()
    {
        Id = $"iev_{Guid.NewGuid():N}";
        CreationDate = DateTime.UtcNow;
    }

    [JsonConstructor]
    public IntegrationEvent(Guid id, DateTime createDate)
    {
        Id = id;
        CreationDate = createDate;
    }

    [JsonInclude]
    public string Id { get; private init; }

    [JsonInclude]
    public DateTime CreationDate { get; private init; }
}
