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

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                IEnumerable<Patrocinador> patrocinadores = await _patrocinadorRepository.GetAll();
                return View(patrocinadores);
            }
            catch(Exception)
            {
                var message = new Message
                {
                    MessageText = "N�o foi possivel buscar os patrocinadores.",
                    IsSuccess = false
                };
                return RedirectToAction("IndexMessage", "Home", message);
            }
        }

        [HttpGet("Alterar/{id}")]
        public async Task<IActionResult> Alterar(int id)
        {
            try
            {
                Patrocinador? patrocinador = await _patrocinadorRepository.GetById(id);
                return View(patrocinador);
            }
            catch (Exception)
            {
                var message = new Message
                {
                    MessageText = "Falha ao buscar o patrocinador.",
                    IsSuccess = false
                };
                return RedirectToAction("IndexMessage", "Home", message);
            }
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
                try
                {
                    string? response = await _patrocinadorRepository.CreateAsync(patrocinador);
                    message.MessageText = response;
                    message.IsSuccess = true;
                }catch (Exception)
                {
                    message.IsSuccess = false;
                    message.MessageText = "Falha ao registrar novo patrocinador.";
                }
                return RedirectToAction("IndexMessage", "Home", message);
            }
            return View(patrocinador);
        }

        [HttpPut("Alterar")]
        public async Task<IActionResult> Alterar(Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                var message = new Message();
                try
                {
                    string? response = await _patrocinadorRepository.UpdateAsync(patrocinador);
                    message.MessageText = response;
                    message.IsSuccess = true;
                }
                catch (Exception)
                {
                    message.IsSuccess = false;
                    message.MessageText = "Falha ao alterar patrocinador.";
                }
                return RedirectToAction("IndexMessage", "Home", message);
            }
            return View(patrocinador);
        }

        [HttpGet("Deletar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = new Message();
            try
            {
                string? response = await _patrocinadorRepository.Delete(id);
                message.IsSuccess = true;
                message.MessageText = response;
                return RedirectToAction("IndexMessage", "Home", message);
            }
            catch(Exception)
            {
                message.IsSuccess = false;
                message.MessageText = "Falha ao deletar Patrocinador.";
                return RedirectToAction("IndexMessage", "Home", message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}