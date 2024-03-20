using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ReadOnlyODataController<TDbContext, TEntity, TKey1, TKey2> : ODataControllerBase<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        [EnableQuery]
        public Task<IQueryable<TEntity>> Get()
            => Task.FromResult(RequestHandler.Get<TEntity>());

        [EnableQuery]
        public async Task<ActionResult<TEntity>> Get(TKey1 key1, TKey2 key2, CancellationToken cancellationToken = default)
            => await RequestHandler.Get<TEntity>([key1, key2], cancellationToken);
    }
}