using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Models.Base
{
    public class DeactivatedModelBase : UserManagedModelBase
    {
        public virtual DateTime? DeactivatedAt { get; set; }
        public virtual int? DeactivatedByUserId { get; set; }
    }
}
