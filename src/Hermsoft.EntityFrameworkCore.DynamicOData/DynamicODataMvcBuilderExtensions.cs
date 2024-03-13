using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hermsoft.EntityFrameworkCore.DynamicOData
{
    public static class DynamicODataMvcBuilderExtensions
    {
        public static IMvcBuilder AddDynamicOData<TDbContext>(this IMvcBuilder builder, Action<DynamicODataOptions<TDbContext>> setupAction)
            where TDbContext : DbContext
        {
            if (builder == null)
            {
                ArgumentNullException.ThrowIfNull(builder);
            }

            if (setupAction == null)
            {
                ArgumentNullException.ThrowIfNull(setupAction);
            }

            builder.AddOData();

            var options = new DynamicODataOptions<TDbContext>();
            setupAction(options);

            builder.Services.AddSingleton<DynamicODataOptions>(options);
            return builder;
        }
    }
}