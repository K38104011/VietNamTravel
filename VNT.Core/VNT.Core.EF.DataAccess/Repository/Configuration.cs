using System.Data.Entity.ModelConfiguration;
using VNT.Core.EF.DataAccess.Model;

namespace VNT.Core.EF.DataAccess.Repository
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(user => new {user.Username});
        }
    }

    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasKey(role => role.Name);
        }
    }

    public class PermissionConfiguration : EntityTypeConfiguration<Permission>
    {
        public PermissionConfiguration()
        {
            HasKey(permission => permission.Name);
        }
    }
}
