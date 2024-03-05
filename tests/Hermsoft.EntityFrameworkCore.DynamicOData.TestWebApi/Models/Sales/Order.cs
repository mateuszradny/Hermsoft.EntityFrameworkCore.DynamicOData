namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales
{
    public class Order
    {
        public required int Id { get; set; }
        public required Guid UserId { get; set; }
        public required DateTimeOffset OderedOn { get; set; }
        public required decimal TotalPrice { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; private set; } = new HashSet<OrderProduct>();
    }
}