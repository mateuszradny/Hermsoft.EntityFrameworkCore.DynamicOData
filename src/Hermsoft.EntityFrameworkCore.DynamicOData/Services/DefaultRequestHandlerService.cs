using Hermsoft.EntityFrameworkCore.DynamicOData.Exceptions;
using Mapster;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Services
{
    public class DefaultRequestHandlerService<TDbContext> : IRequestHandlerService<TDbContext>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public DefaultRequestHandlerService(TDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            _context = context;
        }

        public virtual IQueryable<TEntity> Get<TEntity>()
            where TEntity : class
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public virtual async Task<TEntity> Get<TEntity>(object[] keyValues, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            TEntity? existingEntity = await _context.Set<TEntity>().FindAsync(keyValues, cancellationToken);
            RecordNotFoundException.ThrowIfNull(existingEntity, keyValues);

            return existingEntity!;
        }

        public virtual async Task Delete<TEntity>(object[] keyValues, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            var entity = await _context.Set<TEntity>().FindAsync(keyValues, cancellationToken);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public virtual async Task Patch<TEntity>(object[] keyValues, Delta<TEntity> entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            TEntity? existingEntity = await _context.Set<TEntity>().FindAsync(keyValues, cancellationToken);
            RecordNotFoundException.ThrowIfNull(existingEntity, keyValues);

            entity.Patch(existingEntity!);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Post<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Put<TEntity>(object[] keyValues, TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            TEntity? existingEntity = await _context.Set<TEntity>().FindAsync(keyValues, cancellationToken);
            RecordNotFoundException.ThrowIfNull(existingEntity, keyValues);

            entity.Adapt(existingEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}