using System.Security.Cryptography;

namespace CaExam.Helpers
{

    public static class PasswordHasher
    {
        public static byte[] GenerateSalt(int size = 16)
        {
            byte[] salt = new byte[size];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }
    

    public static byte[] HashPassword(byte[] password, byte[] salt, int iterations = 10000, int hashSize = 32)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(hashSize);
        }
    }

    public static bool VerifyPassword(byte[] password, byte[] salt, byte[] hash, int iterations = 10000, int hashSize = 32)
    {
        byte[] hashToVerify = HashPassword(password, salt, iterations, hashSize);
        return hash.SequenceEqual(hashToVerify);
    }
}
}
