using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TesteSmartHint.Domain.Entities
{
    public class Pessoa
    {
        public Pessoa() { }

        protected Pessoa(int id, string nome, string email, long telefone, DateTime dtCadastro, bool bloqueado, long? inscricaoEstadual)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            this.dtCadastro = dtCadastro;
            Bloqueado = bloqueado;
            InscricaoEstadual = inscricaoEstadual;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        public DateTime dtCadastro { get; set; }
        public bool Bloqueado { get; set; }
        public long? InscricaoEstadual { get; set; }
    }
}
