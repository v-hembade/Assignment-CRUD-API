using JwtRoleBase.Model;
using Microsoft.EntityFrameworkCore;

namespace JwtRoleBase.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
