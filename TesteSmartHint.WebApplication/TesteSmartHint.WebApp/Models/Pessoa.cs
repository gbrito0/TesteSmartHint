using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSmartHint.WebApp.Models
{
    public class Pessoa
    {
        public Pessoa() { }

        public Pessoa(int id, string nome, string email, string telefone, DateTime dtCadastro, bool bloqueado, string inscricaoEstadual, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            this.dtCadastro = dtCadastro;
            Bloqueado = bloqueado;
            InscricaoEstadual = inscricaoEstadual;
            Senha = senha;
        }

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