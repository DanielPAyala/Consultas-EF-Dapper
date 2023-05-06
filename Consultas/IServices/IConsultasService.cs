using Consultas.Models;

namespace Consultas.IServices
{
    public interface IConsultasService
    {
        List<ElementoConsulta> ConsultaDepartamentosConEmpleados();
        List<ElementoConsulta> ConsultaDepartamentosEmpleadosDesconectados();
        List<ElementoConsulta> ConsultaDepartamentos_ConsultaExclusiva();
        List<ElementoConsulta> ConsultaDepartamentos_ConsultaInclusiva();
        List<ElementoConsulta> ConsultaTotal();
    }
}
