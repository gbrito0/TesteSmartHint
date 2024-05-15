using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TesteSmartHint.WebApp.DTO
{
    public class PessoaJuridicaDTO
    {
        public int CodigoEmpresa { get; set; }
        public string RazaoSocial { get; set; }

        string _cnpj;
        public string CNPJ
        {
            get { return _cnpj; }
            set { _cnpj = Regex.Replace(value, @"[^\d]", ""); } //retorna apenas numeros}
        }
    }
}