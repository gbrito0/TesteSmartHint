using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using TesteSmartHint.WebApp.DTO;
using TesteSmartHint.WebApp.Mapeamentos;
using TesteSmartHint.WebApp.Models;

namespace TesteSmartHint.WebApp.BLL
{
    public class PessoaFisicaBLL
    {

        public static bool ValidaCPF(HttpClient client, string cpf)
        {
            HttpResponseMessage response = client.GetAsync($"api/PessoaFisica/ValidaCPF?CPF={cpf}").Result;

            if (response.IsSuccessStatusCode)
            {
                var retorno = response.Content.ReadAsAsync<bool>().Result;
                return retorno;
            }
            else
                return false;
        }

        public static bool CadastraPessoaFisica(HttpClient client, PessoaFisica pessoaFisica)
        {
            var mapper = AutoMapperConfig.InicializarProfiles();
            var pessoaDTO = mapper.Map<PessoaFisicaDTO>(pessoaFisica);

            var json = JsonConvert.SerializeObject(pessoaDTO);
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/PessoaFisica", jsonContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var obj = response.Content.ReadAsAsync<PessoaDTO>().Result;
                return true;
            }
            else
                return false;
        }  
    }
}