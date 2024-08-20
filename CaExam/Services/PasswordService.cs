using CaExam.Helpers;
using CaExam.Interfaces;

namespace CaExam.Services
{
    public class PasswordService : IPasswordService
    {
        public bool VerifyPassword(byte[] password, byte[] salt, byte[] hash)
        {
            return PasswordHasher.VerifyPassword(password, salt, hash);
        }

        public byte[] GenerateHash(byte[] password, byte[] salt)
        {
            return PasswordHasher.HashPassword(password, salt);
        }
        public byte[] GenerateSalt()
        {
            return PasswordHasher.GenerateSalt();
        }

    }
}
