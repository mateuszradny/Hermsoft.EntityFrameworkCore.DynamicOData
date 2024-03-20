using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ODataController<TDbContext, TEntity, TKey> : ReadOnlyODataController<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class
    {
        public async Task<IActionResult> Post([FromBody] TEntity entity, CancellationToken cancellationToken = default)
        {
            await RequestHandler.Post(entity, cancellationToken);
            return Created();
        }

        public async Task<IActionResult> Put(TKey key, [FromBody] TEntity entity, CancellationToken cancellationToken = default)
        {
            await RequestHandler.Put([key], entity, cancellationToken);
            return Ok();
        }

        public async Task<IActionResult> Patch(TKey key, [FromBody] Delta<TEntity> entity, CancellationToken cancellationToken = default)
        {
            await RequestHandler.Patch([key], entity, cancellationToken);
            return Ok();
        }

        public async Task<IActionResult> Delete(TKey key, CancellationToken cancellationToken = default)
        {
            await RequestHandler.Delete<TEntity>([key], cancellationToken);
            return Ok();
        }
    }
}