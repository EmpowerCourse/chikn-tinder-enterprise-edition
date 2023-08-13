using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Common.Dtos.Base
{
    public class UserManagedEntityDtoBase : EntityDtoBase
    {
        public DateTime? CreatedAt { get; set; }
        public int? CreatedByUserId { get; set; }
    }
}
