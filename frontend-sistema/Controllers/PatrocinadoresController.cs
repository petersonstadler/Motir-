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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
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
            return View(new Patrocinador());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Patrocinador patrocinador)
        {
            return RedirectToAction("ListarTodos");
        }
    }
}