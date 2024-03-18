using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity
{
    [PrimaryKey(nameof(UserId), nameof(RoleId))]
    public class UserRole
    {
        public required Guid UserId { get; set; }
        public required Guid RoleId { get; set; }

        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}