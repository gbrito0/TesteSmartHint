using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace TesteSmartHint.Application.DTOs
{
    public class PessoaJuridicaDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "Codigo da Empresa inválido")]
        public int CodigoEmpresa { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? RazaoSocial { get; set; }

        [SwaggerSchema(ReadOnly = true)]        
        public string? Email { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public long Telefone { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [MinLength(14)]
        [MaxLength(14)]
        public string CNPJ { get; set; }       
    }
}
