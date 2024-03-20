using Bogus;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data
{
    public static class FakeData
    {
        public static List<User> Users = [];
        public static List<Role> Roles = [];
        public static List<UserRole> UserRoles = [];

        public static List<Order> Orders = [];
        public static List<Product> Products = [];
        public static List<OrderProduct> OrderProducts = [];

        private static Faker<User> _userFaker = new Faker<User>()
                .RuleFor(x => x.Id, _ => Guid.NewGuid())
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.Name))
                .RuleFor(x => x.Password, f => f.Internet.Password());

        public static void Init(int count)
        {
            Users = _userFaker.Generate(count);

            var roleFaker = new Faker<Role>()
                .RuleFor(x => x.Id, _ => Guid.NewGuid())
                .RuleFor(x => x.Name, f => f.Name.JobTitle());

            Roles = roleFaker.Generate(count);

            var userRoleFaker = new Faker<UserRole>()
                .RuleFor(x => x.RoleId, f => f.PickRandom(Roles).Id)
                .RuleFor(x => x.UserId, f => f.PickRandom(Users).Id);

            UserRoles = userRoleFaker.Generate(count * 20).DistinctBy(x => new { x.UserId, x.RoleId }).ToList();

            var orderId = 1;
            var orderFaker = new Faker<Order>()
                .RuleFor(x => x.Id, _ => orderId++)
                .RuleFor(x => x.OderedOn, f => f.Date.BetweenOffset(DateTimeOffset.Now.AddYears(-5), DateTimeOffset.Now))
                .RuleFor(x => x.UserId, f => f.PickRandom(Users).Id)
                .RuleFor(x => x.TotalPrice, f => f.Random.Decimal(10, 7000));

            Orders = orderFaker.Generate(count);

            var productFaker = new Faker<Product>()
                .RuleFor(x => x.Id, _ => Guid.NewGuid())
                .RuleFor(x => x.Category, f => f.Random.Enum<ProductCategory>())
                .RuleFor(x => x.Description, f => f.Lorem.Lines(5))
                .RuleFor(x => x.Price, f => f.Random.Decimal(10, 500));

            Products = productFaker.Generate(count);

            var orderProductsFaker = new Faker<OrderProduct>()
                .RuleFor(x => x.OrderId, f => f.PickRandom(Orders).Id)
                .RuleFor(x => x.ProductId, f => f.PickRandom(Products).Id)
                .RuleFor(x => x.Number, f => f.Random.Int(1, 10));

            OrderProducts = orderProductsFaker.Generate(count * 2).DistinctBy(x => new { x.OrderId, x.ProductId }).ToList();
        }

        public static User CreateUser()
            => _userFaker.Generate();
    }
}