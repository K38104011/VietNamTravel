using System.Collections.Generic;

namespace VNT.Core.EF.DataAccess.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }
    }
}
