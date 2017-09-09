using System.Data.Entity;
using VNT.Core.EF.DataAccess.Repository;
using VNT.Core.Model;

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
