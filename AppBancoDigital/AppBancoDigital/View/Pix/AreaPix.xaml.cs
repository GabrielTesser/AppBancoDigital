using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDigital.Model;
using AppBancoDigital.View.PopUp;
using Xamarin.Essentials;
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
                btn_criar.Text = "Criar Chave Pix";
                txt_tipo.IsVisible = false;
                btn_copiar.IsVisible = false;
            }
            else
            {
                txt_chave.Text = App.DadosChavePix.Chave.ToString();
                btn_criar.Text = "Alterar Chave Pix";
            }
        }

        private void btn_criar_Clicked(object sender, EventArgs e)
        {
            if (App.DadosChavePix.Chave == null)
            {
                App.Current.MainPage = new PixAdd();
            }
            else
            {
                App.Current.MainPage = new PixAdd();
                //ainda não tem
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(App.DadosChavePix.Chave);
        }
    }
}