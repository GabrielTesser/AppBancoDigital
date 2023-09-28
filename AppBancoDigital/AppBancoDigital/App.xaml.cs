using AppBancoDigital.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital
{
    public partial class App : Application
    {
        public static Correntista DadosCorrentista { get; set; } = new Correntista();
        public static Conta DadosConta { get; set; } = new Conta();
        public static ChavePix DadosChavePix { get; set; } = new ChavePix();


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
