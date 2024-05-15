using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TesteSmartHint.WebApp.DTO
{
    public class PessoaFisicaDTO
    {
        public int CodigoPessoa { get; set; }        
        string _cpf;
        public string CPF
        {
            get { return _cpf; }
            set { _cpf = Regex.Replace(value, @"[^\d]", ""); } //retorna apenas numeros
        }
        public string Genero { get; set; }
        public DateTime dtNascimento { get; set; }
    }
}