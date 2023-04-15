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

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            try
            {
                var patrocinador = await _repository.GetById(id);
                if (patrocinador != null)
                    return Ok(patrocinador);
                else return BadRequest("Falha ao buscar patrocinador.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Patrocinador patrocinador)
        {
            if(!await _repository.Novo(patrocinador))
                return BadRequest("Falha ao tentar criar patrocinador!");
            return Ok("Patrocinador registrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Patrocinador patrocinador)
        {
            if(!await _repository.Atualizar(id, patrocinador))
                return BadRequest("Falha ao tentar alterar patrocinador!");
            return Ok("Patrocinador alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if(!await _repository.Deletar(id))
                return BadRequest("Falha ao tentar excluir patrocinador!");
            return Ok("Patrocinador deletado com sucesso!");
        }

        [HttpGet("GetPaginated")]
        public async Task<IActionResult> GetPaginated(int pageIndex, int pageSize)
        {
            return Ok(await _repository.GetPaginated(pageIndex, pageSize));
        }
    }
}