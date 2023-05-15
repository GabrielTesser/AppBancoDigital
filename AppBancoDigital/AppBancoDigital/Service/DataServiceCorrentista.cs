using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {
        public static async Task<Correntista> Cadastrar(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/salvar");

            Correntista p = JsonConvert.DeserializeObject<Correntista>(json);

            return p;
        }
        public static async Task<Correntista> Autorizar(Correntista c)
        {
            var json_to_send = JsonConvert.SerializeObject(c);

            string json = await DataService.GetDataFromService(String.Format("/correntista/entrar?cpf={0}&senha={1}", c.Cpf, c.Senha));

            Correntista correntista = new Correntista();
            if (json != "false")
            {
                correntista = JsonConvert.DeserializeObject<Correntista>(json);
            }


            return correntista;
        }


    }
}
