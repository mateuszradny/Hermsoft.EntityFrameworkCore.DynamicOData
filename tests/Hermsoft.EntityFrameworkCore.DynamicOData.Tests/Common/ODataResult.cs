namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common
{
    public class ODataResult<TEntity>
    {
        public TEntity[] value { get; set; }
    }
}