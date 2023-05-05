using Consultas.Entidades;
using Consultas.IRepositories;
using Consultas.Models;
using Dapper;

namespace Consultas.Repositories
{
    public class DapperRepository : IConsultasRepository
    {
        private readonly DapperContext _context;
        private readonly string camposSelect = "A.DepartamentoId AS DepartamentoId, A.Nombre AS DepartamentoNombre, B.EmpleadoId AS EmpleadoId, B.Nombre AS EmpleadoNombre";

        public DapperRepository(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public List<ElementoConsulta> ConsultaDepartamentos_ConsultaInclusiva()
        {
            var query = $"SELECT {camposSelect} FROM dbo.Departamento A LEFT JOIN dbo.Empleado B ON A.DepartamentoId = B.DepartamentoId";
            return ConsultaGenerica(query);
        }

        private List<ElementoConsulta> ConsultaGenerica(string query)
        {
            var lista = new List<ElementoConsulta>();
            using (var connection = _context.CreateConnection())
            {
                var resultado = connection.Query<ElementoConsulta>(query);
                lista = resultado.ToList();
            }
            return lista;
        }
    }
}
