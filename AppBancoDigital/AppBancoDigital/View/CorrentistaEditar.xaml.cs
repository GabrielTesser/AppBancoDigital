using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDigital.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorrentistaEditar : ContentPage
    {
        bool Avatar;
        public CorrentistaEditar()
        {
            InitializeComponent();


            if (Avatar == false)
            {
                avatar.Source = ImageSource.FromResource("AppBancoDigital.imagens.avatar.png");
                avatar.Aspect = Aspect.AspectFit;

            }
            else
            {
                avatar.Source = App.DadosCorrentista.SelectedImage;
                
            }
            string correntista = "Nome: " + App.DadosCorrentista.Nome;
            string cpf = "Nome: " + App.DadosCorrentista.Cpf;
            string email = "Nome: " + App.DadosCorrentista.Email;

            txt_correntista.Text = correntista;
            txt_cpf.Text = cpf;
            txt_email.Text = email;

            btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.fechado.png");

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
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

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Selecione uma imagem"
                });

                if (result != null)
                {

                    Avatar = true;

                    avatar.Source = ImageSource.FromFile(result.FullPath);
                    App.DadosCorrentista.SelectedImage = ImageSource.FromFile(result.FullPath);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine(ex.StackTrace);
                await DisplayAlert("Ops!", ex.Message, "OK");
            }
        }
    }
}