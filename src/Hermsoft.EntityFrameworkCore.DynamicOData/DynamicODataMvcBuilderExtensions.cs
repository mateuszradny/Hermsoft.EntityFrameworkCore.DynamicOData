using Hermsoft.EntityFrameworkCore.DynamicOData.Infrastructure;
using Hermsoft.EntityFrameworkCore.DynamicOData.Services;
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

            var options = new DynamicODataOptions<TDbContext>();
            setupAction(options);
            builder.Services.AddSingleton<DynamicODataOptions>(options);
            builder.Services.AddHttpContextAccessor();

            builder.AddOData((x, provider) =>
            {
                using var scope = builder.Services.BuildServiceProvider().CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<TDbContext>();

                x.EnableQueryFeatures();
                x.AddRouteComponents(options.RoutePrefix, context.GetEdmModel());
            }).ConfigureApplicationPartManager(x =>
            {
                if (!x.FeatureProviders.Any(x => x.GetType() == typeof(DynamicODataControllerFeatureProvider)))
                    x.FeatureProviders.Add(new DynamicODataControllerFeatureProvider(builder.Services.BuildServiceProvider()));
            });

            builder.Services.AddScoped<IRequestHandlerService<TDbContext>, DefaultRequestHandlerService<TDbContext>>();

            return builder;
        }
    }
}