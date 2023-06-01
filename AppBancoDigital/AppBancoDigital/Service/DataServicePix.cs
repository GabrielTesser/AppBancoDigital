﻿using System;
using Newtonsoft.Json;
using AppBancoDigital.Model;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDigital.Service
{
    public class DataServicePix
    {
        public static async Task<Transacao> EnviarAsync(Transacao t)
        {
            var json_a_enviar = JsonConvert.SerializeObject(t);

            string json = await DataService.PostDataToService(json_a_enviar, "/pix/enviar");

            return JsonConvert.DeserializeObject<Transacao>(json);
        }

        public static async Task<Transacao> ReceberAsync(Transacao t)
        {
            var json_a_enviar = JsonConvert.SerializeObject(t);

            string json = await DataService.PostDataToService(json_a_enviar, "/pix/receber");

            return JsonConvert.DeserializeObject<Transacao>(json);
        }
    }
}