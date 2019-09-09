using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFirebaseAuth.Services;

namespace XFFirebaseAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        IAuth auth;
        public CreateAccountPage()
        {
            InitializeComponent();

            auth = DependencyService.Get<IAuth>();
        }

        async void SalveUserClicked(object sender, EventArgs e) 
        {
            var token = auth.SignUpWithEmailPassword(EmailInput.Text, PasswordInput.Text);
            if (token == null)
            {
                await Navigation.PushAsync(new LoggedPage());
                ShowSuccess();
            }
            else
                ShowError(token);
        }

        private async void ShowSuccess()
        {
            await DisplayAlert("Sucesso!", "Usuário criado com sucesso!", "OK");
        }

        private async void ShowError(string mensagem)
        {
            await DisplayAlert("Ops!", mensagem, "OK");
        }
    }
}