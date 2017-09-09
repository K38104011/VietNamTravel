using System.Collections.Generic;

namespace VNT.Core.EF.DataAccess.Model
{
    public class Permission
    {
        public string Name { get; private set; }
        public ICollection<Role> Roles { get; set; }

        public Permission()
        {
            Roles = new List<Role>();
        }

        public Permission(string name)
        {
            Name = name;
            Roles = new List<Role>();
        }
    }
}
