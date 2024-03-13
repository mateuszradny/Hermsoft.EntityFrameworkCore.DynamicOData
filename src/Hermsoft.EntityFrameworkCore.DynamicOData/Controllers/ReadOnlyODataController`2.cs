using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ReadOnlyODataController<TDbContext, TEntity> : ODataController
        where TDbContext : DbContext
        where TEntity : class
    {
        [EnableQuery]
        public async Task<IQueryable<TEntity>> Get()
        {
            await Task.Yield();
            throw new NotImplementedException();
        }
    }
}