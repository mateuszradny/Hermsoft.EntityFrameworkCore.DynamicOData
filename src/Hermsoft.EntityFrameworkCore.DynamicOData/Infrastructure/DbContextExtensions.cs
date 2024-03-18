using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Infrastructure
{
    internal static class DbContextExtensions
    {
        public static IEdmModel GetEdmModel(this DbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            var modelBuilder = new ODataConventionModelBuilder();

            foreach (var entity in context.Model.GetEntityTypes())
            {
                var entityType = modelBuilder.AddEntityType(entity.ClrType);

                foreach (var keyPropery in entity.FindPrimaryKey().Properties)
                    entityType.HasKey(keyPropery.PropertyInfo);

                modelBuilder.AddEntitySet(entity.DisplayName(), entityType);
            }

            return modelBuilder.GetEdmModel();
        }
    }
}