using Consultas.IServices;
using Consultas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Consultas.Controllers
{
    public class HomeController : BaseController
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

            var path = _configuration["Parametros:RutaTrabajo"];
            var argumento = ObtenerNarrativa(indice, path);

            ObtenerParametrosRetorno(argumento);

            return View(lista);
        }

        private void ObtenerParametrosRetorno(Argumento argumento)
        {
            ViewBag.Titulo = argumento.Titulo;
            ViewBag.Descripcion = argumento.Descripcion;
            ViewBag.Codigo = argumento.Codigo;
            ViewBag.Imagen = argumento.Imagen;
            ViewBag.NombreArchivoExcel = argumento.NombreArchivoExcel;
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
                case 1:
                    resultado = _consultasService.ConsultaDepartamentos_ConsultaExclusiva();
                    break;
                case 2:
                    resultado = _consultasService.ConsultaTotal();
                    break;
                case 3:
                    resultado = _consultasService.ConsultaDepartamentosConEmpleados();
                    break;
                case 4:
                    resultado = _consultasService.ConsultaDepartamentosEmpleadosDesconectados();
                    break;
                case 5:
                    resultado = _consultasService.ConsultaEmpleados_ConsultaInclusiva();
                    break;
                case 6:

                    break;
            }
            return resultado;
        }
    }
}