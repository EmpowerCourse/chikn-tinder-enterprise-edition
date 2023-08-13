using ChiknTinder.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Persistence.NHibernate.Mappings.Base
{
    public class UserManagedModelBaseMap<T> : ModelBaseMap<T> where T : UserManagedModelBase
    {
        public UserManagedModelBaseMap(string tableName) : base(tableName)
        {
            Map(x => x.CreatedAt).Nullable();
            Map(x => x.CreatedByUserId).Nullable();
        }
    }
}
