using ChiknTinder.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Persistence.NHibernate.Mappings.Base
{
    public class DeactivatedModelBaseMap<T> : UserManagedModelBaseMap<T> where T : DeactivatedModelBase
    {
        public DeactivatedModelBaseMap(string tableName) : base(tableName)
        {
            Map(x => x.DeactivatedAt).Nullable();
            Map(x => x.DeactivatedByUserId).Nullable();
        }
    }
}
