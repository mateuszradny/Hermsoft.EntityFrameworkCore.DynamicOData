using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ReadOnlyODataController<TEntity, TKey> : ODataController
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