using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorrentistaEditar : ContentPage
    {
        public CorrentistaEditar()
        {
            InitializeComponent();

            avatar.Source = ImageSource.FromResource("AppBancoDigital.imagens.avatar.png");
            string correntista = "Nome: " + App.DadosCorrentista.Nome;
            string cpf = "Nome: " + App.DadosCorrentista.Cpf;
            string email = "Nome: " + App.DadosCorrentista.Email;

            txt_correntista.Text = correntista;
            txt_cpf.Text = cpf;
            txt_email.Text = email;




        }
    }
}