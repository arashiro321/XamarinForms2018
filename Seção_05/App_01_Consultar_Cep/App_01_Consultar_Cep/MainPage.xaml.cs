using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_01_Consultar_Cep.Servico.Modelo;
using App_01_Consultar_Cep.Servico;

namespace App_01_Consultar_Cep
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;           
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereco: {2} de {3}, {0} - {1}", end.Localidade, end.Uf, end.Logradouro, end.Bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O Endereco nao foi encontrado para o CEP informado: " + cep, "OK");  
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }

                
            }                       
        }

        private bool isValidCEP(string cep)
        {
            bool valid = true;
            int NovoCep = 0;

            //if (cep.Length != 8)
            //{
            //    DisplayAlert("ERRO", "CEP invalido! O CEP deve conter 8 caracteres.", "OK");
            //    valid = false;
            //}

            if (!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("ERRO", "CEP invalido! O CEP deve ser composto apenas por numeros.", "OK");
                valid = false;
            }
            return valid;
        }
    }
}
