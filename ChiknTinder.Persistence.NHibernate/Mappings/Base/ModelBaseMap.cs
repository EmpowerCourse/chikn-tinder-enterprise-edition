using ChiknTinder.Models.Base;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Persistence.NHibernate.Mappings.Base
{
    public class ModelBaseMap<T> : ClassMap<T> where T : ModelBase
    {
        public ModelBaseMap(string tableName)
        {
            Id(x => x.Id);
            Table(tableName);
        }
    }
}
