using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSmartHint.Application.DTOs;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaDTO>> GetAll();
        Task<PessoaDTO> GetPessoaAsync(int id);
        Task<PessoaDTO> Add(PessoaDTO pessoa);
        Task<PessoaDTO> Update(PessoaDTO pessoa);
        Task Delete(int id);
        Task<bool> ValidaEmail(string Email);
        Task<bool> ValidaInscricaoEstadual(string inscricaoEstadual);
    }
}

