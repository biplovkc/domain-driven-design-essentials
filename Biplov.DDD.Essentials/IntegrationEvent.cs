namespace Biplov.DDD.Essentials;

public record IntegrationEvent
{        
    public IntegrationEvent()
    {
        Id = $"iev_{Guid.NewGuid():N}";
        CreationDate = DateTime.UtcNow;
    }

    [JsonConstructor]
    public IntegrationEvent(string id, DateTime createDate)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(id));
            
        Id = id;
        CreationDate = createDate;
    }

    [JsonInclude]
    public string Id { get; private init; }

    [JsonInclude]
    public DateTime CreationDate { get; private init; }
}
