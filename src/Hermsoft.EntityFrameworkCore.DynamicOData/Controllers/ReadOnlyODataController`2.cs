using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ReadOnlyODataController<TDbContext, TEntity> : ODataControllerBase<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        [EnableQuery]
        public Task<IQueryable<TEntity>> Get()
            => Task.FromResult(RequestHandler.Get<TEntity>());
    }
}