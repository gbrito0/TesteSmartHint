using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace TesteSmartHint.Application.DTOs
{
    public class PessoaDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int CodigoPessoa { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(1)]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [MinLength(1)]
        [MaxLength(150)]
        public string Email { get; set; }
        
        [Range(1, 99999999999, ErrorMessage = "Telefone inválido")]
        public long Telefone { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime dtCadastro { get; set; }

        public bool Bloqueado { get; set; }
        public long? InscricaoEstadual { get; set; }
        public string Senha { get; set; }   
    }
}
