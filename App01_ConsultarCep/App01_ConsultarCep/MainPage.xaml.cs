using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCep.Servico.Modelo;
using App01_ConsultarCep.Servico;

namespace App01_ConsultarCep
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
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0} , {1} - {2} / {3}", end.Logradouro, end.Bairro, end.Localidade, end.UF);
                    }
                    else
                    {
                        DisplayAlert("ERRO-00", "O CEP,'" + cep + "', NÃO FOI ENCONTRADO", "OK");
                    }

                   
                } catch(Exception e)
                {
                    DisplayAlert("ERRO Critíco", e.Message, "OK");
                }

            }
                              
        }

        private bool isValidCEP(string cep)
        {
            bool Valido = true; 

            if (cep.Length != 8)
            {   DisplayAlert("ERRO-01", "CEP inválido, o CEP deve conter 8 digitos","OK");
                Valido = false; 
            }

            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO-02", "CEP inválido, o CEP deve conter somente dígitos númericos", "OK");
                Valido = false;
            }
            return Valido;
        }
	}
}
