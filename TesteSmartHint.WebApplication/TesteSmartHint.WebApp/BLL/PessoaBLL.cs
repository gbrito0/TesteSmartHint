using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TesteSmartHint.WebApp.DTO;
using TesteSmartHint.WebApp.Mapeamentos;
using TesteSmartHint.WebApp.Models;

namespace TesteSmartHint.WebApp.BLL
{
    public class PessoaBLL
    {

        public static List<Pessoa> RetornaPessoas(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Pessoa").Result;
            if (response.IsSuccessStatusCode)
            {
                var registros = response.Content.ReadAsAsync<IEnumerable<PessoaDTO>>().Result;

                var mapper = AutoMapperConfig.InicializarProfiles();
                var retorno = mapper.Map<IEnumerable<Pessoa>>(registros);

                return retorno.ToList();
            }
            else
                return null;
        }
        public static List<Pessoa> RetornaPessoasByFiltro(HttpClient client, IDictionary<string,string> filtros)
        {
            var uri = new UriBuilder($"{client.BaseAddress}api/Pessoa/GetByFiltros");
            var query = HttpUtility.ParseQueryString(uri.Query);

            foreach(var obj in filtros)
            {
                query.Set(HttpUtility.UrlEncode(obj.Key), obj.Value);
            }
            uri.Query= query.ToString();
            
            HttpResponseMessage response = client.GetAsync(uri.ToString()).Result;

            
            if (response.IsSuccessStatusCode)
            {
                var registros = response.Content.ReadAsAsync<IEnumerable<PessoaDTO>>().Result;

                var mapper = AutoMapperConfig.InicializarProfiles();
                var retorno = mapper.Map<IEnumerable<Pessoa>>(registros);

                return retorno.ToList();
            }
            else
                return null;
        }
        public static bool ValidaEmail(HttpClient client, string email)
        {
            HttpResponseMessage response = client.GetAsync($"api/Pessoa/ValidaEmail?email={email}").Result;
            
            if (response.IsSuccessStatusCode)
            {
                var retorno= response.Content.ReadAsAsync<bool>().Result;
                return retorno;
            }
            else
                return false;            
        }

        public static Pessoa CadastraPessoa(HttpClient client, Pessoa pessoa)
        {
            var mapper = AutoMapperConfig.InicializarProfiles();
            var pessoaDTO = mapper.Map<PessoaDTO>(pessoa);
            pessoaDTO.InscricaoEstadual = pessoaDTO.InscricaoEstadual == null ? null : Regex.Replace(pessoaDTO.InscricaoEstadual, @"[^\d]", "");

            var json = JsonConvert.SerializeObject(pessoaDTO);
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/Pessoa", jsonContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var obj = response.Content.ReadAsAsync<PessoaDTO>().Result;                
                return mapper.Map<Pessoa>(obj);
            }
            else
                return null;            
        }
    }
}