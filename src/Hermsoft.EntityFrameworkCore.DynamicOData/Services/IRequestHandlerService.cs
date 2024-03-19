using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Services
{
    public interface IRequestHandlerService<TDbContext>
        where TDbContext : DbContext
    {
        IQueryable<TEntity> Get<TEntity>()
            where TEntity : class;

        Task<TEntity> Get<TEntity>(object[] keyValues, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task Post<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task Put<TEntity>(object[] keyValues, TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task Patch<TEntity>(object[] keyValues, Delta<TEntity> entity, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task Delete<TEntity>(object[] keyValues, CancellationToken cancellationToken = default)
            where TEntity : class;
    }
}