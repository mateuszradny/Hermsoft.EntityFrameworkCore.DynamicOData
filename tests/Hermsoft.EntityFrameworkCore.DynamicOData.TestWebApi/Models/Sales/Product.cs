namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales
{
    public enum ProductCategory
    {
        Sports,
        Computers,
        Clothes
    }

    public class Product
    {
        public required Guid Id { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required ProductCategory Category { get; set; }
    }
}