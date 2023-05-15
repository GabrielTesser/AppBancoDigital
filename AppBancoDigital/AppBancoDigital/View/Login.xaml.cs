using AppBancoDigital.Model;
using AppBancoDigital.Service;
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
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //try
            //{
            //    Console.WriteLine(txt_cpf.Text);
            //    Correntista c = await DataServiceCorrentista.Autorizar(new Correntista
            //    {
            //        Senha = txt_cpf.Text,
            //        Cpf = txt_cpf.Text
            //    });

            //    if (c.Id != 0)
            //    {
            //        string msg = $"Correntista logado com sucesso. Código gerado: {c.Id} ";

            //        await DisplayAlert("Sucesso!", msg, "OK");

            //        await Navigation.PushAsync(new View.Home());
            //    }
            //    else
            //    {
            //        string msg = $"Correntista não encontrado, tente logar novamente! ";

            //        await DisplayAlert("Erro!", msg, "OK");

            //        await Navigation.PushAsync(new View.Login());
            //    }

            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Ops", ex.Message, "OK");
            //}




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
                await DisplayAlert("ops!", "usuario ou senha incorreto.", "OK");

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