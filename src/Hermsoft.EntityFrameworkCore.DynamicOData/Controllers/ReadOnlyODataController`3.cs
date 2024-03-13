using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ReadOnlyODataController<TDbContext, TEntity, TKey> : ODataController
        where TDbContext : DbContext
        where TEntity : class
    {
        [EnableQuery]
        public async Task<IQueryable<TEntity>> Get()
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        [EnableQuery]
        public async Task<TEntity> Get(TKey key)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }
    }
}