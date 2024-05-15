﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSmartHint.WebApp.DTO
{
    public class PessoaDTO
    {
        public int CodigoPessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        public DateTime dtCadastro { get; set; }
        public bool Bloqueado { get; set; }
        public long? InscricaoEstadual { get; set; }
    }
}