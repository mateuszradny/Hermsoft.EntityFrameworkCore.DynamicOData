using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderProduct
    {
        public required int OrderId { get; set; }
        public required Guid ProductId { get; set; }
        public required int Number { get; set; }

        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}