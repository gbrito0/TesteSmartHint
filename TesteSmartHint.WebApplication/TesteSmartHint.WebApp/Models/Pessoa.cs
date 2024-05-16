using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSmartHint.WebApp.Models
{
    public class Pessoa
    {
        public Pessoa() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime dtCadastro { get; set; }
        public bool Bloqueado { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Senha { get; set; }
    }
}