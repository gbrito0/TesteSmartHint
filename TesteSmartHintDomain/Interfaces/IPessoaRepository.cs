using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Domain.Interfaces
{
    public interface IPessoaRepository<T> where T : Pessoa
    {
        public Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
        Task<bool> ValidaCampo(string campo);
    }
}
