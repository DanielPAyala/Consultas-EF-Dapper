using Consultas.Models;

namespace Consultas.IRepositories
{
    public interface IConsultasRepository
    {
        List<ElementoConsulta> ConsultaDepartamentosConEmpleados();
        List<ElementoConsulta> ConsultaDepartamentosEmpleadosDesconectados();
        List<ElementoConsulta> ConsultaDepartamentos_ConsultaExclusiva();
        List<ElementoConsulta> ConsultaDepartamentos_ConsultaInclusiva();
        List<ElementoConsulta> ConsultaTotal();
    }
}
