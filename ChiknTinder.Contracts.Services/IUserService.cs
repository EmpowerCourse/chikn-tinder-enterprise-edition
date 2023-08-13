using ChiknTinder.Common.Dtos;
using ChiknTinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Contracts.Services
{
    public interface IUserService
    {
        Task<UserDto?> Authenticate(string username, string password);
    }
}
