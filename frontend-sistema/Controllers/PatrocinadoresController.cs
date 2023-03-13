using frontend_sistema.Models;
using frontend_sistema.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontend_sistema.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PatrocinadoresController : Controller
    {
        private readonly ILogger<PatrocinadoresController> _logger;
        private readonly IPatrocinadorRepository _patrocinadorRepository;

        public PatrocinadoresController(ILogger<PatrocinadoresController> logger, IPatrocinadorRepository patrocinadorRepository)
        {
            _logger = logger;
            _patrocinadorRepository = patrocinadorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            IEnumerable<Patrocinador> patrocinadores = await _patrocinadorRepository.GetAll();
            return View(patrocinadores);
        }

        [HttpGet("Registrar")]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar(Patrocinador patrocinador)
        {
            if(ModelState.IsValid)
            {
                var message = new Message();
                var response = string.Empty;
                try
                {
                    response = await _patrocinadorRepository.CreateAsync(patrocinador);
                    message.MessageText = response;
                    message.IsSuccess = true;
                }catch (Exception ex)
                {
                    message.IsSuccess = false;
                    message.MessageText = "Falha ao registrar novo patrocinador.";
                }
                return RedirectToAction("IndexMessage", "Home", message);
            }
            return View(patrocinador);
        }

        [HttpPut("Alterar/{id}")]
        public IActionResult Alterar(int id, [FromBody] Patrocinador patrocinador)
        {
            if(ModelState.IsValid)
            {
                
            }
            return RedirectToAction("MessagePage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}