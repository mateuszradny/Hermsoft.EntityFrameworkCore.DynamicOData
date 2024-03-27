using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset OderedOn { get; set; }
        public decimal TotalPrice { get; set; }

        public User User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; private set; } = new HashSet<OrderProduct>();
    }
}