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
    }
}
