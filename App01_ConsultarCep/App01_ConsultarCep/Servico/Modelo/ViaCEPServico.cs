using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCep.Servico.Modelo;
using Newtonsoft.Json;

/* *********************************************** */
/* Realiza a pesquisa do cep informado pelo usuario*/
/* *********************************************** */

namespace App01_ConsultarCep.Servico.Modelo
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(String CEP)
        {
            String NovoEnderecoURL = String.Format(EnderecoURL, CEP);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoURL);
      
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.Cep == null) return null;

            return end;
        }
    }
}
