using ChiknTinder.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Models
{
    public class Role : ModelBase
    {
        public virtual string Name { get; set; } = default!;
        public virtual IList<User> Users { get; set; } = default!;
    }
}
