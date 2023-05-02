using Consultas.Entidades;
using Consultas.IRepositories;
using Consultas.Models;

namespace Consultas.Repositories
{
    public class JoinsRepository : IConsultasRepository
    {
        private readonly ConsultasContext _context;

        public JoinsRepository(ConsultasContext context)
        {
            _context = context;
        }

        public List<ElementoConsulta> ConsultaDepartamentos_ConsultaInclusiva()
        {
            var lista = (from d in _context.Departamentos
                         join e in _context.Empleados
                         on d.DepartamentoId equals e.DepartamentoId
                         into emp from empleado in emp.DefaultIfEmpty()
                         select new ElementoConsulta
                         {
                             EmpleadoNombre = empleado == null ? null : empleado.Nombre,
                             EmpleadoId = empleado == null ? null : empleado.EmpleadoId,
                             DepartamentoId = d.DepartamentoId,
                             DepartamentoNombre = d.Nombre
                         }).ToList();

            return lista;
        }
    }
}
