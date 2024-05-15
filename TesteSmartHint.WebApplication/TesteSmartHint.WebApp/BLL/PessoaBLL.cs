using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
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
                var lancamentos = response.Content.ReadAsAsync<IEnumerable<PessoaDTO>>().Result;

                var mapper = AutoMapperConfig.InicializarProfiles();
                var retorno = mapper.Map<IEnumerable<Pessoa>>(lancamentos);

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
                var lancamentos = response.Content.ReadAsAsync<IEnumerable<PessoaDTO>>().Result;

                var mapper = AutoMapperConfig.InicializarProfiles();
                var retorno = mapper.Map<IEnumerable<Pessoa>>(lancamentos);

                return retorno.ToList();
            }
            else
                return null;
        }
    }
}