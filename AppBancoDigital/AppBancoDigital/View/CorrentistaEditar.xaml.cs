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
                avatar.Scale = 1.5;
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




        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
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
    }
}