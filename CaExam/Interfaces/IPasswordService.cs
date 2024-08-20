namespace CaExam.Interfaces
{
    public interface IPasswordService
    {
        byte[] GenerateHash(byte[] password, byte[] salt);
        byte[] GenerateSalt();
        bool VerifyPassword(byte[] password, byte[] salt, byte[] hash);
    }
}