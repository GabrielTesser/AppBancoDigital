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

            txt_correntista.Text = correntista;

            Logo.Source = ImageSource.FromResource("AppBancoDigital.imagens.GT.png");

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

        
    }
}