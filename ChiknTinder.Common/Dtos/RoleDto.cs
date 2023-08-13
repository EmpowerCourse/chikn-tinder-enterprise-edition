using ChiknTinder.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Common.Dtos
{
    public class RoleDto : EntityDtoBase
    {
        public string Name { get; set; } = default!;
    }
}
