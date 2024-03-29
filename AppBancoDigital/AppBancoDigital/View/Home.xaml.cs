﻿using AppBancoDigital.View.Pix;
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
            string saldo = "Seu saldo é de: R" + App.DadosConta.Saldo.ToString("C");

            txt_correntista.Text = correntista;
            txt_cartão1.Text = cartao;
            txt_saldo.Text = saldo;

            Logo.Source = ImageSource.FromResource("AppBancoDigital.imagens.GT.png");
            img_gerar.Source = ImageSource.FromResource("AppBancoDigital.imagens.qr.png");
            img_scan.Source = ImageSource.FromResource("AppBancoDigital.imagens.scan.png");
            img_config.Source = ImageSource.FromResource("AppBancoDigital.imagens.config.png");
            btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.fechado.png");
            img_pix.Source = ImageSource.FromResource("AppBancoDigital.imagens.pix.png");

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
            if (txt_saldo.TextColor == Color.FromHex("#FF0062"))
            {
                txt_saldo.TextColor = Color.White;
                btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.aberto.png");
            }
            else
            {
                txt_saldo.TextColor = Color.FromHex("#FF0062");
                btn_olho.Source = ImageSource.FromResource("AppBancoDigital.imagens.fechado.png");

            }
        }

        private void img_pix_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AreaPix();
        }
    }
}