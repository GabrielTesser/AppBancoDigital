﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace AppBancoDigital.Model
{
    public class Correntista
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Data_Nascimento { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public ImageSource SelectedImage { get; set; }

    }
}
