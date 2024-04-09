using Hermsoft.EntityFrameworkCore.DynamicOData.Services;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Services.HR
{
    public class HRRequestHandlerService : DefaultRequestHandlerService<HRDbContext>
    {
        public HRRequestHandlerService(HRDbContext context) : base(context)
        {
        }

        public override Task Delete<TEntity>(object[] keyValues, CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException("Data deletion not allowed.");
        }
    }
}
