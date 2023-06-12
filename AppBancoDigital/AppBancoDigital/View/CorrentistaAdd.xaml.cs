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
    public partial class CorrentistaAdd : ContentPage
    {
        public CorrentistaAdd()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.aberto.png");
            Logo.Source = ImageSource.FromResource("AppBancoDigital.imagens.GT.png");

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Correntista c = await DataServiceCorrentista.SaveAsync(new Model.Correntista
                {
                    Nome = txt_nome.Text,
                    Email = txt_email.Text,
                    Data_Nascimento = dtpck_data_nasc.Date.ToString("yyyy-MM-dd"),
                    Cpf = txt_cpf.Text.Trim(new Char[] { ' ', '-', '.' }),
                    Senha = txt_senha.Text,
                });

                if (c.Id != null)
                {

                    App.DadosCorrentista = c;

                    await Navigation.PushAsync(new View.Home());
                }
                else
                    throw new Exception("Ocorreu um erro ao salvar seu cadastro.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                await DisplayAlert("Ops!", ex.Message, "OK");
            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Login());
        }

        private void btn_olho_Clicked(object sender, EventArgs e)
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