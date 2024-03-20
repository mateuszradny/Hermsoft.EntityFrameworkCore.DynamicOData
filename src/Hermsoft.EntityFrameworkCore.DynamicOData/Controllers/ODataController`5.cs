using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ODataController<TDbContext, TEntity, TKey1, TKey2, TKey3> : ReadOnlyODataController<TDbContext, TEntity, TKey1, TKey2, TKey3>
        where TDbContext : DbContext
        where TEntity : class
    {
        public async Task<IActionResult> Post([FromBody] TEntity entity, CancellationToken cancellationToken = default)
        {
            await RequestHandler.Post(entity, cancellationToken);
            return Created();
        }

        public async Task<IActionResult> Put(TKey1 key1, TKey2 key2, TKey3 key3, [FromBody] TEntity entity, CancellationToken cancellationToken = default)
        {
            await RequestHandler.Put([key1, key2, key3], entity, cancellationToken);
            return Ok();
        }

        public async Task<IActionResult> Patch(TKey1 key1, TKey2 key2, TKey3 key3, [FromBody] Delta<TEntity> entity, CancellationToken cancellationToken = default)
        {
            await RequestHandler.Patch([key1, key2, key3], entity, cancellationToken);
            return Ok();
        }

        public async Task<IActionResult> Delete(TKey1 key1, TKey2 key2, TKey3 key3, CancellationToken cancellationToken = default)
        {
            await RequestHandler.Delete<TEntity>([key1, key2, key3], cancellationToken);
            return Ok();
        }
    }
}