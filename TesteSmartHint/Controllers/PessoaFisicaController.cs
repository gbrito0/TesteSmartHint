using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Application.Interfaces;
using TesteSmartHint.Application.Services;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly IPessoaService _pessoaService;

        public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService, IPessoaService pessoaService)
        {
            _pessoaFisicaService = pessoaFisicaService;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaFisica>>> GetAll()
        {
            var lstPessoaFisica = await _pessoaFisicaService.GetAll();
            return Ok(lstPessoaFisica);
        }

        [HttpGet("{id}", Name = "GetPessoaFisicaById")]
        public async Task<ActionResult<PessoaFisica>> GetPessoaFisicaById(int id)
        {
            var pessoa = await _pessoaFisicaService.GetPessoaFisicaById(id);
            if (pessoa == null)
                return NotFound();
            else
                return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaFisica pessoaFisica)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pessoaFisicaService.Add(pessoaFisica);
            return Ok(pessoaFisica);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaFisica>> Put(int id, [FromBody] PessoaFisica pessoaFisica)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (id != pessoaFisica.Id)
            {
                ModelState.AddModelError("ErrorMessage", "Id inválido");
                return BadRequest(ModelState);
            }

            var registro = await _pessoaFisicaService.GetPessoaFisicaById(id);
            if (registro == null)
                return NotFound();

            await _pessoaFisicaService.Update(pessoaFisica);
            await _pessoaService.Update(pessoaFisica);

            return Ok(pessoaFisica);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _pessoaFisicaService.GetPessoaFisicaById(id);
            if (registro == null)
                return NotFound();

            await _pessoaFisicaService.Delete(id);
            return Ok();
        }
    }
}
