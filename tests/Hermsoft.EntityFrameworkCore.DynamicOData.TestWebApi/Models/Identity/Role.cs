namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity
{
    public class Role
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; } = new HashSet<UserRole>();
    }
}