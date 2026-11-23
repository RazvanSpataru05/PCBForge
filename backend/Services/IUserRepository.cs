using PCBForge.backend.Models;

namespace backend.backend.Services
{
    public interface IUserRepository
    {
        public Task<User?> GetByEmailAsync(string email);
        public Task AddAsync(User user);
    }
}
