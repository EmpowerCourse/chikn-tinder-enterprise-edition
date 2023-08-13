using ChiknTinder.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Models
{
    public class User : DeactivatedModelBase
    {
        public virtual string Username { get; set; } = default!;
        public virtual string Email { get; set; } = default!;
        public virtual string HashedPassword { get; set; } = default!;
        public virtual string PasswordSalt { get; set; } = default!;
        public virtual IList<Role> Roles { get; set; } = default!;
    }
}
