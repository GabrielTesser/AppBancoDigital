using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDigital.Model;
using AppBancoDigital.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorrentistaListagem : ContentPage
    {
        ObservableCollection<Correntista> ListaCorrentista = new ObservableCollection<Correntista>();
        public CorrentistaListagem()
        {
            InitializeComponent();

            lst_correntista.ItemsSource = ListaCorrentista;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.CorrentistaAdd());
        }
    }
}