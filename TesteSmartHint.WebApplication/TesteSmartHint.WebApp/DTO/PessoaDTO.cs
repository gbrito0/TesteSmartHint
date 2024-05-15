using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TesteSmartHint.WebApp.DTO
{
    public class PessoaDTO
    {
        public int CodigoPessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        string _telefone;
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = Regex.Replace(value, @"[^\d]", ""); } //retorna apenas numeros
        }

        public DateTime dtCadastro { get; set; }
        public bool Bloqueado { get; set; }

        string _inscricaoEstadual;
        public string InscricaoEstadual
        {
            get { return _inscricaoEstadual; }
            set { _inscricaoEstadual = Regex.Replace(value, @"[^\d]", ""); } //retorna apenas numeros
        }
    }
}