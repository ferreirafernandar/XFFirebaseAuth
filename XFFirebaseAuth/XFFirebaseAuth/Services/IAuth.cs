using System.Threading.Tasks;

namespace XFFirebaseAuth.Services
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        string SignUpWithEmailPassword(string email, string password);
        string GetUserEmail();
    }
}