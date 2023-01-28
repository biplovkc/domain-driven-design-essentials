namespace Biplov.DDD.Essentials
{
    public static class DomainEvents
    {
        private static List<Type>? _handlers;

        public static void Init()
        {
            _handlers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetInterfaces()
                    .Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IHandler<>)))
                .ToList();
        }

        public static void Dispatch(IDomainEvent domainEvent)
        {
            if (_handlers is null) return;

            for (var index = 0; index < _handlers.Count; index++)
            {
                var handlerType = _handlers[index];
                var canHandleEvent = handlerType.GetInterfaces()
                    .Any(x => x.IsGenericType
                           && x.GetGenericTypeDefinition() == typeof(IHandler<>)
                           && x.GenericTypeArguments[0] == domainEvent.GetType());

                if (canHandleEvent)
                {
                    dynamic handler = Activator.CreateInstance(handlerType);
                    handler?.Handle((dynamic)domainEvent);
                }
            }
        }
    }
}
