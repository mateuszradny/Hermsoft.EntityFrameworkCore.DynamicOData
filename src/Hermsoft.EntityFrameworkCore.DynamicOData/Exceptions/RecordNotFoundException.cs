namespace Hermsoft.EntityFrameworkCore.DynamicOData.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public required Type EntityType { get; init; }
        public required object[] KeyValues { get; init; }

        public RecordNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public static void ThrowIfNull<TEntity>(TEntity entity, object[] keyValues, Exception? innerException = null)
            where TEntity : class?
        {
            if (entity == null)
                throw new RecordNotFoundException($"'{typeof(TEntity).Name}' record with ids: [{string.Join(", ", keyValues.Select(x => x.ToString()))}] not found.", innerException)
                {
                    EntityType = typeof(TEntity),
                    KeyValues = keyValues,
                };
        }
    }
}