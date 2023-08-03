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
            btn_config.Source = ImageSource.FromResource("AppBancoDigital.imagens.config.png");

            txt_correntista.Text = correntista;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Enviar();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Reber();
        }

        private void btn_config_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CorrentistaEditar();
        }
    }
}