using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSmartHint.WebApp.Models
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica() { }

        public string CPF;
        public string Genero;
        public DateTime dtNascimento;
    }
}