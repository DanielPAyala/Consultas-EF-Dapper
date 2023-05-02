using Consultas.IServices;
using Consultas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Consultas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConsultasService _consultasService;
        private readonly IConfiguration _configuration;



        public HomeController(ILogger<HomeController> logger, IConsultasService consultasService, IConfiguration configuration)
        {
            _logger = logger;
            _consultasService = consultasService;
            _configuration = configuration;
        }

        public IActionResult Index(int indice = 0)
        {
            if (indice < 0 || indice > 6) indice = 0;
            var lista = ObtenerConsulta(indice);
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public List<ElementoConsulta> ObtenerConsulta(int indice)
        {
            var resultado = new List<ElementoConsulta>();
            switch (indice)
            {
                case 0:
                    resultado = _consultasService.ConsultaDepartamentos_ConsultaInclusiva();
                    break;
            }
            return resultado;
        }
    }
}