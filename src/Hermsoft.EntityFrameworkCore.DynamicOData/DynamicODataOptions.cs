namespace Hermsoft.EntityFrameworkCore.DynamicOData
{
    public abstract class DynamicODataOptions
    {
        protected DynamicODataOptions(Type dbContextType)
        {
            ArgumentNullException.ThrowIfNull(dbContextType);

            RoutePrefix = "odata";
            DbContextType = dbContextType;
        }

        public string RoutePrefix { get; set; }
        public Type DbContextType { get; set; }
    }

    public class DynamicODataOptions<TDbContext> : DynamicODataOptions
    {
        public DynamicODataOptions() : base(typeof(TDbContext))
        {
        }
    }
}