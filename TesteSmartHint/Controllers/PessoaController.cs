using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Application.DTOs;
using TesteSmartHint.Application.Interfaces;

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
            var pessoa = await _pessoaService.GetPessoaAsync(id);
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
            if (!ModelState.IsValid)
                return BadRequest();
            if (id != pessoa.Id)
            {
                ModelState.AddModelError("ErrorMessage", "Id inválido");
                return BadRequest(ModelState);
            }

            await _pessoaService.Update(pessoa);

            return Ok(pessoa);
        }

    }
}
