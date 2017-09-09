using System.Data.Entity;
using VNT.Core.EF.DataAccess.Model;
using VNT.Core.EF.DataAccess.Repository;

namespace VNT.Core.EF.DataAccess
{
    public class VietNamTravelDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new PermissionConfiguration());
        }
    }
}
