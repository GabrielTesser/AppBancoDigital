using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        App PropriedadesApp;
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string usuario = txt_cpf.Text;
            string senha = txt_senha.Text;

            string usuario_correto = "111.111.111-11";
            string senha_correta = "123";

            if (usuario == usuario_correto && senha == senha_correta)
            {
                //App.Current.Properties.Add("usuario_logado", usuario);
                App.Current.MainPage = new Home();
            }
            else
                DisplayAlert("ops!", "usuario ou senha incorreto.", "OK");

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.CorrentistaAdd());
        }
    }
}