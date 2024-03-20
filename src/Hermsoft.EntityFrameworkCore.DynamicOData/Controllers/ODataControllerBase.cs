using Hermsoft.EntityFrameworkCore.DynamicOData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Controllers
{
    public abstract class ODataControllerBase<TDbContext, TEntity> : ODataController
        where TDbContext : DbContext
        where TEntity : class
    {
        protected IRequestHandlerService<TDbContext>? _requestHandler;

        protected IRequestHandlerService<TDbContext> RequestHandler => _requestHandler ??= HttpContext.RequestServices.GetRequiredService<IRequestHandlerService<TDbContext>>();
    }
}