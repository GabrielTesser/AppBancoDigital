using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Transacao
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime Data_Hora { get; set; }
        public int Id_Conta_Enviou { get; set; }
        public int Id_Conta_Recebeu { get; set; }
    }
}
