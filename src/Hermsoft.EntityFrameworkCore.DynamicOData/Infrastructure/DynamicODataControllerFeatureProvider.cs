using Hermsoft.EntityFrameworkCore.DynamicOData.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Reflection.Emit;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Infrastructure
{
    internal class DynamicODataControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        private const string DynamicAssemblyName = "Hermsoft.EntityFrameworkCore.DynamicOData.DynamicAssembly";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DynamicODataControllerFeatureProvider(IHttpContextAccessor httpContextAccessor)
        {
            ArgumentNullException.ThrowIfNull(httpContextAccessor);

            _httpContextAccessor = httpContextAccessor;
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var controllerTypes = GetControllerTypes();

            foreach (var controllerType in controllerTypes)
            {
                feature.Controllers.Add(controllerType);
            }
        }

        private TypeInfo[] GetControllerTypes()
        {
            var controllerTypes = new List<TypeInfo>();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                return controllerTypes.ToArray();

            var optionsCollection = httpContext.RequestServices.GetServices<DynamicODataOptions>();
            if (optionsCollection?.Any() == true)
            {
                var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(DynamicAssemblyName), AssemblyBuilderAccess.Run);
                var moduleBuilder = assemblyBuilder.DefineDynamicModule(DynamicAssemblyName);

                foreach (var options in optionsCollection)
                {
                    var context = (httpContext.RequestServices.GetRequiredService(options.DbContextType) as DbContext)!;
                    var entityTypes = context.Model.GetEntityTypes();

                    foreach (var entityType in entityTypes)
                    {
                        var controllerBaseType = GetControllerBaseType(options.DbContextType, entityType);

                        var controllerType = moduleBuilder.DefineType(
                            name: $"{DynamicAssemblyName}.{entityType.Model.ModelId:n}.{entityType.ShortName}Controller",
                            attr: TypeAttributes.Public | TypeAttributes.Class,
                            parent: controllerBaseType);

                        controllerTypes.Add(controllerType.CreateType().GetTypeInfo());
                    }
                }
            }

            return controllerTypes.ToArray();
        }

        private static Type GetControllerBaseType(Type dbContextType, IEntityType entityType)
        {
            var keys = entityType.GetKeys();
            var keyCount = keys.Count();
            var isReadOnly = string.IsNullOrWhiteSpace(entityType.GetTableName());

            var genericBaseType = GetControllerGenericBaseType(isReadOnly, keyCount);

            var types = new List<Type> { dbContextType, entityType.ClrType };
            types.AddRange(keys.Select(x => x.GetKeyType()));

            return genericBaseType.MakeGenericType(types.ToArray());
        }

        private static Type GetControllerGenericBaseType(bool isReadOnly, int keyCount)
            => (isReadOnly, keyCount) switch
            {
                (true, 0) => typeof(ReadOnlyODataController<,>),
                (true, 1) => typeof(ReadOnlyODataController<,,>),
                (true, 2) => typeof(ReadOnlyODataController<,,,>),
                (true, 3) => typeof(ReadOnlyODataController<,,,,>),
                (false, 0) => typeof(ODataController<,>),
                (false, 1) => typeof(ODataController<,,>),
                (false, 2) => typeof(ODataController<,,,>),
                (false, 3) => typeof(ODataController<,,,,>),
                _ => throw new NotSupportedException("Entities with more then 3 keys not supported.")
            };
    }
}