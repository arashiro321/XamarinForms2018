using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App_01_Consultar_Cep.Servico.Modelo;
using Newtonsoft.Json;

namespace App_01_Consultar_Cep.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoUrl = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.Cep == null) return null;

            return end;
        }
    }
}
