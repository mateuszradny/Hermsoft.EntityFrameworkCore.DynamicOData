using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ODataController<TEntity, TKey> : ReadOnlyODataController<TEntity, TKey>
        where TEntity : class
    {
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Put(TKey key, TEntity entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Patch(TKey key, [FromBody] Delta<TEntity> entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Delete(TKey key)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }
    }
}