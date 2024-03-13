﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public class ODataController<TDbContext, TEntity, TKey1, TKey2> : ReadOnlyODataController<TDbContext, TEntity, TKey1, TKey2>
        where TDbContext : DbContext
        where TEntity : class
    {
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Put(TKey1 key1, TKey2 key2, TEntity entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Patch(TKey1 key1, TKey2 key2, [FromBody] Delta<TEntity> entity)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Delete(TKey1 key1, TKey2 key2)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }
    }
}