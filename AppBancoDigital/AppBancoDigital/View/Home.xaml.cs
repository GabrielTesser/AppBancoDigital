using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            string correntista = "Ola " + App.DadosCorrentista.Nome  + "!";
            string cartao = "Nome: " + App.DadosCorrentista.Nome;

            txt_correntista.Text = correntista;
            txt_cartão1.Text = cartao;

            Logo.Source = ImageSource.FromResource("AppBancoDigital.imagens.GT.png");
            img_gerar.Source = ImageSource.FromResource("AppBancoDigital.imagens.qr.png");
            img_scan.Source = ImageSource.FromResource("AppBancoDigital.imagens.scan.png");
            img_config.Source = ImageSource.FromResource("AppBancoDigital.imagens.config.png");
            btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.fechado.png");

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Enviar();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Reber();
        }

        private void btn_config_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CorrentistaEditar();
        }

        private void btn_olho_Clicked(object sender, EventArgs e)
        {
            if (txt_saldo.BackgroundColor == Color.Transparent)
            {
                txt_saldo.BackgroundColor = Color.Black;
                btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.aberto.png");
            }
            else
            {
                txt_saldo.BackgroundColor = Color.Transparent;
                btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.fechado.png");

            }
        }
    }
}