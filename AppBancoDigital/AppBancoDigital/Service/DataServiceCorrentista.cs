using AppBancoDigital.Model;
using AppBancoDigital.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {

        public static async Task<Correntista> LoginAsync(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_a_enviar, "http://10.0.2.2:8000/correntista/entrar");

            return JsonConvert.DeserializeObject<Correntista>(json);
        }

        public static async Task<Correntista> SaveAsync(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_a_enviar, "http://10.0.2.2:8000/correntista/salvar");

            return JsonConvert.DeserializeObject<Correntista>(json);

        }
    }
}
