using AutoMapper;
using ChiknTinder.Common.Dtos;
using ChiknTinder.Contracts.Persistence;
using ChiknTinder.Contracts.Services;
using ChiknTinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiknTinder.Services
{
    public class UserService : IUserService
    {
        private readonly ICryptoService _cryptoService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(ICryptoService cryptoService, IUserRepository userRepository, IMapper mapper)
        {
            _cryptoService = cryptoService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto?> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);
            if (user == null) return null;
            var isPasswordValid = _cryptoService.VerifyPassword(password, user.HashedPassword, user.PasswordSalt);
            if (!isPasswordValid) return null;

            return _mapper.Map<UserDto>(user);
        }
    }
}
