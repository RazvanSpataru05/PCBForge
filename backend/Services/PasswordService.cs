using BC = BCrypt.Net.BCrypt;

namespace backend.backend.Services
{
    public class PasswordService : IPasswordService
    {
        private const int WorkFactor = 12;

        public string Hash(string password)
        { 
            return BC.HashPassword(password, WorkFactor);
        }

        public bool Verify(string hash, string password)
        {
            return hash == Hash(password);
        }
    }
}
