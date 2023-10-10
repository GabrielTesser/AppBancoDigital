using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDigital.Model;
using AppBancoDigital.View.Pix;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PixAdd : ContentPage
    {
        public PixAdd()
        {
            InitializeComponent();

            
        }

        private void chk_cpf_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chk_cpf.IsChecked == true)
            {
                txt_chave.Placeholder = "000.000.000-00";
                chk_email.IsChecked = false;
                chk_telefone.IsChecked = false;

                txt_chave.Text = App.DadosCorrentista.Cpf;
                txt_chave.IsEnabled = false;

                chk_telefone.IsEnabled = true;
                chk_email.IsEnabled = true;
                chk_cpf.IsEnabled = false;
            }
        }

        private async void chk_email_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            if (chk_email.IsChecked == true)
            {
                txt_chave.Placeholder = "email@email.com";
                chk_cpf.IsChecked = false;
                chk_telefone.IsChecked = false;
                txt_chave.Text = null; 
                txt_chave.IsEnabled = true;

                txt_chave.Text = App.DadosCorrentista.Email;
                await DisplayAlert("!", "Por favor confirme seu email", "OK");

                chk_telefone.IsEnabled = true;
                chk_email.IsEnabled = false;
                chk_cpf.IsEnabled = true;
            }
        }

        private void chk_telefone_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chk_telefone.IsChecked == true)
            {
                txt_chave.Placeholder = "00000-0000";
                chk_email.IsChecked = false;
                chk_cpf.IsChecked = false;
                txt_chave.Text = null;
                txt_chave.IsEnabled = true;

                chk_telefone.IsEnabled = false;
                chk_email.IsEnabled = true;
                chk_cpf.IsEnabled = true;

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
             App.Current.MainPage = new AreaPix();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if(txt_chave.Text != null)
            {
                App.DadosChavePix.Chave = txt_chave.Text;


                if(chk_cpf.IsChecked == true)
                {
                    App.DadosChavePix.Tipo = "cpf";
                }
                else if (chk_telefone.IsChecked == true) 
                {
                    App.DadosChavePix.Tipo = "telefone";
                }
                else if (chk_email.IsChecked == true) 
                { 
                    App.DadosChavePix.Tipo = "email";
                }

                App.Current.MainPage = new AreaPix();
            }
            else
            {
                await DisplayAlert("Campo vazio", "Por Favor informe a chave", "ok");
            }
        }
    }
}