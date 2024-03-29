﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reber : ContentPage
    {
        public Reber()
        {
            InitializeComponent();

            zxing.OnScanResult += (result) => Device.BeginInvokeOnMainThread(() => {lblResult.Text = result.Text;});
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing() 
        {
            zxing.IsScanning = false;

            base.OnDisappearing(); 
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
    }
}