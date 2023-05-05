using Consultas.IRepositories;
using Consultas.IServices;
using Consultas.Models;

namespace Consultas.Services
{
    public class DapperService : IConsultasService
    {
        private readonly IConsultasRepository _consultasRepository;

        public DapperService(IConsultasRepository consultasRepository)
        {
            _consultasRepository = consultasRepository;
        }

        public List<ElementoConsulta> ConsultaDepartamentos_ConsultaInclusiva()
        {
            return _consultasRepository.ConsultaDepartamentos_ConsultaInclusiva();
        }
    }
}
