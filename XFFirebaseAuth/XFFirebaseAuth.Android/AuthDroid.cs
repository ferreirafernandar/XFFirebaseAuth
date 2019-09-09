using Firebase.Auth;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFFirebaseAuth.Droid;
using XFFirebaseAuth.Services;

[assembly: Dependency(typeof(AuthDroid))]
namespace XFFirebaseAuth.Droid
{
    public class AuthDroid : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var usuario = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var senha = await usuario.User.GetIdTokenAsync(false);

                return senha.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        public string SignUpWithEmailPassword(string email, string password)
        {
            var signUpTask = FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);
            return signUpTask.Exception?.Message;
        }

        public string GetUserEmail()
        {
            return FirebaseAuth.Instance.CurrentUser.Email;
        }
    }
}