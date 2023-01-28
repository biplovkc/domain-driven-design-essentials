namespace Biplov.DDD.Essentials;

/// <summary>
/// Handler interface for IDomainEvent
/// </summary>
/// <typeparam name="T">Domain event that inherits IDomainEvent</typeparam>
public interface IHandler<in T> where T : IDomainEvent
{
    /// <summary>
    /// Domain event handler function.
    /// </summary>
    /// <param name="domainEvent">IDomainEvent</param>
    void Handle(T domainEvent);
}