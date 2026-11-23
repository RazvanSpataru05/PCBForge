using PCBForge.backend.Models;

namespace backend.backend.Services
{
    public interface IRoleRepository
    {
        public Task<Role> GetByNameAsync(string name);
    }
}
