using System;
using System.ComponentModel;
using Xamarin.Forms;
using XFFirebaseAuth.Services;

namespace XFFirebaseAuth
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IAuth auth;
        public MainPage()
        {
            InitializeComponent();

            auth = DependencyService.Get<IAuth>();
        }

        async void LoginClicked(object sender, EventArgs e) 
        {
            var token = await auth.LoginWithEmailPassword(EmailInput.Text, PasswordInput.Text);
            if (token != "")
                await Navigation.PushAsync(new LoggedPage());
            else
                ShowError();
        }

        //private async void LoginFacebookClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new FacebookLogin());
        //}

        async void CreateAccountClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccountPage());
        }

        private async void ShowError()
        {
            await DisplayAlert("Ops!", "E-mail ou senha incorretos. Tente novamente!", "OK");
        }
    }
}
