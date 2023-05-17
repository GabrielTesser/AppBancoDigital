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
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {
                Correntista c = await DataServiceCorrentista.Cadastrar(new Correntista
                {
                    Nome = txt_nome.Text,
                    Senha = txt_senha.Text,
                    Data_Nasc = dtpck_data_nasc.Date.ToString("yyyy-MM-dd"),
                    Cpf = txt_cpf.Text
                });

                string msg = $"Correntista inserido com sucesso. Código gerado: {c.Id} ";

                await DisplayAlert("Sucesso!", msg, "OK");

                await Navigation.PushAsync(new View.Login());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                act_carregando.IsRunning = false;
                act_carregando.IsVisible = false;
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