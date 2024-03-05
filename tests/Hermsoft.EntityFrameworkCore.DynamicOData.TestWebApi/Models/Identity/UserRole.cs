using System.ComponentModel.DataAnnotations;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity
{
    public class UserRole
    {
        [Key]
        public required Guid UserId { get; set; }

        [Key]
        public required Guid RoleId { get; set; }

        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}