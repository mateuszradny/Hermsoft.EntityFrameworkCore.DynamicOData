using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermsoft.EntityFrameworkCore.DynamicOData
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDynamicOData(this IServiceCollection services)
        {
            return services;
        }
    }
}
