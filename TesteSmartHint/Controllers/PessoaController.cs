using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteSmartHint.Application.DTOs;
using TesteSmartHint.Application.Interfaces;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaDTO>>> GetAll()
        {
            var lstPessoaFisica = await _pessoaService.GetAll();
            return Ok(lstPessoaFisica);
        }

        [HttpGet("{id}", Name = "GetPessoaById")]
        public async Task<ActionResult<PessoaDTO>> GetById(int id)
        {
            var pessoa = await _pessoaService.GetPessoaById(id);
            if (pessoa == null)
                return NotFound();
            else
                return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pessoaService.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaDTO pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var retorno = await _pessoaService.Add(pessoa);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaDTO>> Put(int id, [FromBody] PessoaDTO pessoa)
        {
            pessoa.CodigoPessoa = id;
            await _pessoaService.Update(pessoa);

            return Ok(pessoa);
        }

        [HttpGet("ValidaEmail")]
        public async Task<ActionResult<bool>> ValidaEmail(string email)
        {
            var emailEncontrado = await _pessoaService.ValidaEmail(email);
            return (Ok(!emailEncontrado));
        }

        [HttpGet("GetByFiltros")]
        public async Task<IActionResult> GetByFiltros([FromQuery] Dictionary<string, string> filtros)
        {
            //http://localhost/api/products?filter={"name":"Test","price":10}
            //var filterDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(filtros);
            /*
                         * {
              "Nome": "guilherme",
              "Telefone": "11987367440"
            }
             */

            if (filtros == null)
                return BadRequest();
            
            var pessoas = await _pessoaService.GetByFiltro(filtros);
            if (pessoas == null || pessoas.Count() == 0)
                return NotFound();
            else
                return (Ok(pessoas));
        }
    }
}
