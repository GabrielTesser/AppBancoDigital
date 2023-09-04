using AppBancoDigital.Model;
using AppBancoDigital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit;



namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorrentistaAdd : ContentPage
    {
        bool Avatar;

        public CorrentistaAdd()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.aberto.png");
            dtpck_data_nasc.MaximumDate = DateTime.Now.AddYears(-16);



            if (Avatar == false)
            {
                avatar.Source = ImageSource.FromResource("AppBancoDigital.imagens.avatar.png");
            }
            else
            {
                avatar.Source = App.DadosCorrentista.SelectedImage;

            }
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
                    Cpf = txt_cpf.Text.Trim('-', ' ', '.'),
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

        private async void Button_Clicked_2(object sender, EventArgs e)
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
            catch(Exception ex)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine(ex.StackTrace);
                await DisplayAlert("Ops!", ex.Message, "OK");
            }

        }
    }
}