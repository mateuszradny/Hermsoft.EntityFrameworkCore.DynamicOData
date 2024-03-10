namespace Hermsoft.EntityFrameworkCore.DynamicOData
{
    public class DynamicODataOptions
    {
        public DynamicODataOptions()
        {
            RoutePrefix = "odata";
        }

        public string RoutePrefix { get; set; }
    }
}