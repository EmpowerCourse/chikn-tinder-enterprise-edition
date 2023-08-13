using ChiknTinder.Contracts.Persistence;
using ChiknTinder.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Persistence.NHibernate.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;

        public UserRepository(ISession session)
        {
            _session = session;
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _session.Query<User>().SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
