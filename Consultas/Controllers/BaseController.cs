using Consultas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consultas.Controllers
{
    public class BaseController : Controller
    {
        public Argumento ObtenerNarrativa(int indice, string path)
        {
            var archivo = "Narrativa.txt";
            string rutaCompleta = Path.Combine(path, archivo);
            var lineas = System.IO.File.ReadAllLines(rutaCompleta);

            rutaCompleta = Path.Combine(path, indice + ".jpg");
            var imageBase64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(rutaCompleta));

            var argumento = lineas[indice].Split('|');
            var elemento = new Argumento
            {
                Titulo = argumento[0],
                Descripcion = argumento[1],
                Codigo = argumento[2],
                Imagen = imageBase64,
                NombreArchivoExcel = argumento[3]
            };

            return elemento;
        }
    }
}
