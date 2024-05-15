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
    public class PessoaJuridicaBLL
    {
        public static bool ValidaCNPJ(HttpClient client, string cnpj)
        {
            HttpResponseMessage response = client.GetAsync($"api/PessoaJuridica/ValidaCNPJ?CNPJ={cnpj}").Result;

            if (response.IsSuccessStatusCode)
            {
                var retorno = response.Content.ReadAsAsync<bool>().Result;
                return retorno;
            }
            else
                return false;
        }

        public static bool CadastraPessoaJuridica(HttpClient client, PessoaJuridica pessoaJuridica)
        {
            var mapper = AutoMapperConfig.InicializarProfiles();
            var pessoaJuridicaDTO = mapper.Map<PessoaJuridicaDTO>(pessoaJuridica);

            var json = JsonConvert.SerializeObject(pessoaJuridicaDTO);
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/PessoaJuridica", jsonContent).Result;

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