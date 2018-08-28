using System;
using System.Collections.Generic;
using System.Text;

namespace App_01_Consultar_Cep.Servico.Modelo
{
    public class Endereco
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string IBGE { get; set; }
        public string GIA { get; set; }
    }
}
