using backend_api.Models;
using backend_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatrocinadoresController : ControllerBase
    {
        private readonly ILogger<PatrocinadoresController> _logger;
        private readonly IPatrocinadorRepository _context;

        public PatrocinadoresController(IPatrocinadorRepository patrocinadores, ILogger<PatrocinadoresController> logger)
        {
            _logger = logger;
            _context = patrocinadores;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.GetAll());
        }

        [HttpGet("GetByResposavel/{responsavel}")]
        public async Task<IActionResult> GetByResposavel(string responsavel)
        {
            return Ok(await _context.GetByResponsavel(responsavel.ToUpper()));
        }

        [HttpPost]
        public async Task<ActionResult> Post(Patrocinador patrocinador)
        {
            if(!await _context.Novo(patrocinador))
                return NotFound("Patrocinador não encontrado!");
            return Ok(patrocinador);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, Patrocinador patrocinador)
        {
            if(!await _context.Atualizar(id, patrocinador))
                return NotFound("Patrocinador não encontrado!");
            return Ok(patrocinador);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if(!await _context.Deletar(id))
                return NotFound("Patrocinador não encontrado!");
            return Ok("Deletado com sucesso!");
        }
    }
}