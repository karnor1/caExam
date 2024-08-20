namespace CaExam.Interfaces
{
    public interface IUserAccountService
    {
        Task< bool> RegisterAsync(string username, string password);
    }
}