using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ODataController<TEntity, TKey1, TKey2, TKey3> : ReadOnlyODataController<TEntity, TKey1, TKey2, TKey3>
            where TEntity : class
    {
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Put(TKey1 key1, TKey2 key2, TKey3 key3, TEntity entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Patch(TKey1 key1, TKey2 key2, TKey3 key3, [FromBody] Delta<TEntity> entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Delete(TKey1 key1, TKey2 key2, TKey3 key3)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }
    }
}