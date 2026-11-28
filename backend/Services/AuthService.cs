using backend.backend.Exceptions;
using backend.backend.Models.DTOs;
using PCBForge.backend.Models;

namespace backend.backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthService(
            IPasswordService passwordService,
            IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<User> RegisterAsync(RegisterDto dto)
        {
            var email = dto.Email.Trim().ToLowerInvariant();

            if (await _userRepository.GetByEmailAsync(email) != null)
                throw new EmailAlreadyExistsException("Email already exists.");

            var role = await _roleRepository.GetByNameAsync("user")
                    ?? throw new InvalidOperationException("Default role 'user' is missing from the database.");

            var user = new User
            {   
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PasswordHash = _passwordService.Hash(dto.Password),
                Email = dto.Email.ToLower(),
                RoleId = role.Id
            };

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> LoginAsync(LoginDto dto)
        {
            var email = dto.Email.Trim().ToLowerInvariant();
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null || !_passwordService.Verify(user.PasswordHash, dto.Password))
            {
                throw new InvalidOperationException("Email or password are incorrect.");
            }

            return user;
        }
    }
}
