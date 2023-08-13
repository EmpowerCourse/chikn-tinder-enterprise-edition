using ChiknTinder.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Common.Dtos
{
    public class UserDto : DeactivatedEntityDtoBase
    {
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public IList<RoleDto> Roles { get; set; } = default!;
    }
}
