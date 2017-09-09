using System.Collections.Generic;

namespace VNT.Core.Model
{
    public class Role
    {
        public string Name { get; private set; }
        public ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }

        public Role(string name)
        {
            Name = name;
            Users = new List<User>();
        }
    }
}
