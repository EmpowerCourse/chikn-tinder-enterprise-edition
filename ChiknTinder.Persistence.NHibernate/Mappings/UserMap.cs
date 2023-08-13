using ChiknTinder.Models;
using ChiknTinder.Persistence.NHibernate.Mappings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Persistence.NHibernate.Mappings
{
    public class UserMap : DeactivatedModelBaseMap<User>
    {
        public UserMap() : base("Users")
        {
            Map(x => x.Username);
            Map(x => x.Email);
            Map(x => x.HashedPassword);
            Map(x => x.PasswordSalt);
            HasManyToMany(x => x.Roles)
                .Cascade.All()
                .Table("UserRoles")
                .ParentKeyColumn("UserId")
                .ChildKeyColumn("RoleId");
        }
    }
}
