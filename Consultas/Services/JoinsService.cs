using Consultas.IRepositories;
using Consultas.IServices;
using Consultas.Models;

namespace Consultas.Services
{
    public class JoinsService : IConsultasService
    {
        private readonly IConsultasRepository _consultasRepository;

        public JoinsService(IConsultasRepository consultasRepository)
        {
            _consultasRepository = consultasRepository;
        }

        public List<ElementoConsulta> ConsultaDepartamentos_ConsultaInclusiva()
        {
            return _consultasRepository.ConsultaDepartamentos_ConsultaInclusiva();
        }

        public List<ElementoConsulta> ConsultaDepartamentos_ConsultaExclusiva()
        {
            return _consultasRepository.ConsultaDepartamentos_ConsultaExclusiva();
        }

        public List<ElementoConsulta> ConsultaTotal()
        {
            return _consultasRepository.ConsultaTotal();
        }

        public List<ElementoConsulta> ConsultaDepartamentosConEmpleados()
        {
            return _consultasRepository.ConsultaDepartamentosConEmpleados();
        }

        public List<ElementoConsulta> ConsultaDepartamentosEmpleadosDesconectados()
        {
            return _consultasRepository.ConsultaDepartamentosEmpleadosDesconectados();
        }

        public List<ElementoConsulta> ConsultaEmpleados_ConsultaInclusiva()
        {
            return _consultasRepository.ConsultaEmpleados_ConsultaInclusiva();
        }
    }
}
