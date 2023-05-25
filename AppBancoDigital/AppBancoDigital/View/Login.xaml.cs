using AppBancoDigital.Model;
using AppBancoDigital.Service;
using AppBancoDigital.View;
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
            btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.aberto.png");
            Logo.Source = ImageSource.FromResource("AppBancoDigital.imagens.GT.png");


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Model.Correntista c = await DataServiceCorrentista.LoginAsync(new Model.Correntista
                {
                    Cpf = txt_cpf.Text,
                    Senha = txt_senha.Text,
                });

                if (c.Id != null)
                {
                    App.DadosCorrentista = c;
                    App.Current.MainPage = new NavigationPage(new View.Home());
                }
                else
                    throw new Exception("Dados de login inválidos.");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "OK");
            }



            //string usuario = txt_cpf.Text;
            //string senha = txt_senha.Text;

            //string usuario_correto = "111.111.111-11";
            //string senha_correta = "123";

            //if (usuario == usuario_correto && senha == senha_correta)
            //{
            //    //App.Current.Properties.Add("usuario_logado", usuario);
            //    App.Current.MainPage = new Home();
            //}
            //else
            //    await DisplayAlert("ops!", "usuario ou senha incorreto.", "OK");

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.CorrentistaAdd());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if (txt_senha.IsPassword == true) 
            {
                txt_senha.IsPassword = false;
                btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.fechado.png");
            }
            else
            {
                txt_senha.IsPassword = true;
                btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.aberto.png");
            }
        }
    }
}