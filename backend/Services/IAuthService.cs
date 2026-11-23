using backend.backend.Models.DTOs;
using PCBForge.backend.Models;

namespace backend.backend.Services
{
    public interface IAuthService
    {
        public Task<User> RegisterAsync(RegisterDto dto);
        public Task<User> LoginAsync(LoginDto dto);
    }
}
