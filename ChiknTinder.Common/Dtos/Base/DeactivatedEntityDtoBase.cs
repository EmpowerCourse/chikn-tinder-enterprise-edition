using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Common.Dtos.Base
{
    public class DeactivatedEntityDtoBase : UserManagedEntityDtoBase
    {
        public DateTime? DeactivatedAt { get; set; }
        public int? DeactivatedByUserId { get; set; }
    }
}
