using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDigital.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaPix : ContentPage
    {
        public AreaPix()
        {
            InitializeComponent();

            if (App.DadosChavePix.Chave == null)
            {
                txt_chave.Text = "Você ainda não possui chave pix";
            }
            else
            {
                txt_chave.Text = App.DadosChavePix.Chave.ToString();
            }
        }

        private async void btn_criar_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}