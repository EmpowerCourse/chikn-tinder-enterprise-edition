using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Models
{
    public class Chicken
    {
        public virtual User User { get; set; } = default!;
        public virtual string Name { get; set; } = default!;
        public virtual int Age { get; set; }
        public virtual string Description { get; set; } = default!;
        public virtual string ImageUrl { get; set; } = default!;
    }
}
