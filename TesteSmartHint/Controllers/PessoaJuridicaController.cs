using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Application.Interfaces;
using TesteSmartHint.Application.Services;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaService _pessoaJuridicaService;
        private readonly IPessoaService _pessoaService;

        public PessoaJuridicaController(IPessoaJuridicaService pessoaJuridicaService, IPessoaService pessoaService)
        {
            _pessoaJuridicaService = pessoaJuridicaService;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaJuridica>>> GetAll()
        {
            var lstPessoaJuridica = await _pessoaJuridicaService.GetAll();
            return Ok(lstPessoaJuridica);
        }

        [HttpGet("{id}", Name = "GetPessoaJuridicaById")]
        public async Task<ActionResult<PessoaJuridica>> GetPessoaJuridicaById(int id)
        {
            try
            {
                var pessoa = await _pessoaJuridicaService.GetPessoaJuridicaById(id);
                if (pessoa == null)
                    return NotFound();
                else
                    return Ok(pessoa);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaJuridica pessoaJuridica)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _pessoaJuridicaService.Add(pessoaJuridica);
                return Ok(pessoaJuridica);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaJuridica>> Put(int id, [FromBody] PessoaJuridica pessoaJuridica)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (id != pessoaJuridica.Id)
            {
                ModelState.AddModelError("ErrorMessage", "Id inválido");
                return BadRequest(ModelState);
            }

            await _pessoaJuridicaService.Update(pessoaJuridica);
            await _pessoaService.Update(pessoaJuridica);
            
            return Ok(pessoaJuridica);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            await _pessoaJuridicaService.Delete(id);
            return Ok();
        }
    }
}
