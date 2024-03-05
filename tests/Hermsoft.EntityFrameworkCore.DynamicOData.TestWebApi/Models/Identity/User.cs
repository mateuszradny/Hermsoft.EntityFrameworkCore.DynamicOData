using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity
{
    public class User
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        [NotMapped]
        public required string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; } = new HashSet<UserRole>();
        public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();
    }
}