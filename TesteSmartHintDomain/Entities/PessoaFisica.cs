﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSmartHint.Domain.Entities
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica() { }

        protected PessoaFisica(int id, string nome, string email, long telefone, DateTime dtCadastro,
            bool bloqueado, long? inscricaoEstadual, string senha, string CPF, string Genero, DateTime dtNascimento) : base(id, nome, email, telefone, dtCadastro, bloqueado, inscricaoEstadual, senha)
        {
            this.CPF = CPF;
            this.Genero = Genero;
            this.dtNascimento = dtNascimento;
        }

        public string CPF { get; set; }
        public string Genero { get; set; }
        public DateTime dtNascimento { get; set; }

    }
}
