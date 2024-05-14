using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Application.Interfaces;
using TesteSmartHint.Application.Services;
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
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAll()
        {
            var lstPessoaFisica = await _pessoaService.GetAll();
            return Ok(lstPessoaFisica);
        }

        [HttpGet("{id}", Name = "GetPessoaById")]
        public async Task<ActionResult<Pessoa>> GetById(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoaAsync(id);
                if (pessoa == null)
                    return NotFound();
                else
                    return Ok(pessoa);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pessoaService.Delete(id);
            return Ok();
        }

        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody]Pessoa pessoa)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        await _pessoaService.Add(pessoa);
        //        return Ok(pessoa);
        //    }catch(Exception ex)
        //    {
        //        return StatusCode(500, ex.Message); 
        //    }            
        //}


        //[HttpPut("{id}")]
        //public async Task<ActionResult<Pessoa>> Put(int id, [FromBody] Pessoa pessoa)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    if (id != pessoa.Id)
        //    {
        //        ModelState.AddModelError("ErrorMessage", "Id inválido");
        //        return BadRequest(ModelState);
        //    }

        //    await _pessoaService.Update(pessoa);

        //    return Ok(pessoa);
        //}

    }
}
