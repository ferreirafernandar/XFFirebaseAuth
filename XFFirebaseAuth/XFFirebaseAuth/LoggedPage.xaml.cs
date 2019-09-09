
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFirebaseAuth.Services;

namespace XFFirebaseAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoggedPage : ContentPage
    {
        IAuth auth;

        public LoggedPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            txtEmail.Text = $"Bem-vindo \n {auth?.GetUserEmail()}";
        }
    }
}