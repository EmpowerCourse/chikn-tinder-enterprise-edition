using ChiknTinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetByUsername(string username);
    }
}
