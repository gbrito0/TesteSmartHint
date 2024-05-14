using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace TesteSmartHint.Application.DTOs
{
    public class PessoaFisicaDTO
    {        
        [Range(1, int.MaxValue, ErrorMessage = "Codigo da Pessoa inválido")]
        public int CodigoPessoa { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Nome { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Email { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public long Telefone { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [MinLength(11)]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Genero é obrigatório")]
        [MinLength(1)]
        [MaxLength(9)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
        public DateTime dtNascimento { get; set; }

    }
}
