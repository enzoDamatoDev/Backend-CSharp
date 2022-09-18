using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Switch.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Switch.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            return View(id);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id.HasValue)
            {
                CadastroViewModel p = Repositorio.Respostas.First(u=>u.id == id);
                return View(p);
            }

            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(CadastroViewModel resp)
        {
            if (ModelState.IsValid)
            {
                Repositorio.AdicionarResposta(resp);
                return View("Salvo");
            }
            else
            {
                return View(resp);
            }
        }
        public IActionResult Lista()
        {
            return View(Repositorio.Respostas);
        }

        public IActionResult Remover(int id)
        {
            TempData["excluiu"]=Repositorio.remover(id);
            return View("Salvo");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
