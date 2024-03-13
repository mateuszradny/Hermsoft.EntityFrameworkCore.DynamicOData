using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ODataController<TDbContext, TEntity> : ReadOnlyODataController<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }
    }
}