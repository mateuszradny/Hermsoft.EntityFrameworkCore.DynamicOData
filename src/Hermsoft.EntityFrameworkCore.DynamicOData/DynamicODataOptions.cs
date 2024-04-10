using Hermsoft.EntityFrameworkCore.DynamicOData.Services;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData
{
    public abstract class DynamicODataOptions
    {
        protected DynamicODataOptions(Type dbContextType)
        {
            ArgumentNullException.ThrowIfNull(dbContextType);

            RoutePrefix = "odata";
            DbContextType = dbContextType;
            IsEntityTypeAutorized = _ => false;
            RequestHandlerServiceType = typeof(DefaultRequestHandlerService<>).MakeGenericType(dbContextType);
        }

        public string RoutePrefix { get; set; }
        public Type DbContextType { get; set; }
        public Type RequestHandlerServiceType { get; set; }
        public Predicate<Type> IsEntityTypeAutorized { get; set; }
    }

    public class DynamicODataOptions<TDbContext> : DynamicODataOptions
        where TDbContext : DbContext
    {
        public DynamicODataOptions() : base(typeof(TDbContext))
        {
        }

        public DynamicODataOptions<TDbContext> WithRequestHandlerService<TRequestHandlerService>()
            where TRequestHandlerService : IRequestHandlerService<TDbContext>
        {
            RequestHandlerServiceType = typeof(TRequestHandlerService);
            return this;
        }
    }
}