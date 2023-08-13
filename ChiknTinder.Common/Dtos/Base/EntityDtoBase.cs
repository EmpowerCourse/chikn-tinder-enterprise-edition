using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Common.Dtos.Base
{
    public class EntityDtoBase
    {
        // The id is nullable to allow for creation of new entities.
        public int? Id { get; set; }
    }
}
