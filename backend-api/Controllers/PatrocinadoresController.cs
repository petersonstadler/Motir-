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
        private readonly IPatrocinadorRepository _repository;

        public PatrocinadoresController(IPatrocinadorRepository patrocinadoresRepo, ILogger<PatrocinadoresController> logger)
        {
            _logger = logger;
            _repository = patrocinadoresRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("GetByResposavel/{responsavel}")]
        public async Task<IActionResult> GetByResposavel(string responsavel)
        {
            return Ok(await _repository.GetByResponsavel(responsavel.ToUpper()));
        }

        [HttpPost]
        public async Task<ActionResult> Post(Patrocinador patrocinador)
        {
            if(!await _repository.Novo(patrocinador))
                return NotFound("Falha ao tentar criar patrocinador!");
            return Ok(patrocinador);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, Patrocinador patrocinador)
        {
            if(!await _repository.Atualizar(id, patrocinador))
                return NotFound("Falha ao tetnar alterar patrocinador!");
            return Ok(patrocinador);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if(!await _repository.Deletar(id))
                return NotFound("Falha ao tentar excluir patrocinador!");
            return Ok("Deletado com sucesso!");
        }
    }
}