using ChiknTinder.Models;
using ChiknTinder.Persistence.NHibernate.Mappings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Persistence.NHibernate.Mappings
{
    public class RoleMap : ModelBaseMap<Role>
    {
        public RoleMap() : base("Roles")
        {
            Map(x => x.Name);
            HasManyToMany(x => x.Users)
                .Cascade.All()
                .Inverse()
                .Table("UserRoles")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserId");
        }
    }
}
