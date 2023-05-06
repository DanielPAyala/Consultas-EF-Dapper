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

        public List<ElementoConsulta> ConsultaDepartamentos_ConsultaExclusiva()
        {
            var lista = (from d in _context.Departamentos
                         join e in _context.Empleados
                         on d.DepartamentoId equals e.DepartamentoId
                         into emp
                         from empleado in emp.DefaultIfEmpty()
                         where empleado.DepartamentoId == null
                         select new ElementoConsulta
                         {
                             DepartamentoId = d.DepartamentoId,
                             DepartamentoNombre = d.Nombre
                         }).ToList();

            return lista;
        }

        public List<ElementoConsulta> ConsultaTotal()
        {
            var leftOuterJoin = from left in _context.Departamentos
                                join right in _context.Empleados
                                on left.DepartamentoId equals right.DepartamentoId
                                into temp
                                from right in temp.DefaultIfEmpty()
                                select new { left, right };

            var rightOuterJoin = from right in _context.Empleados
                                 join left in _context.Departamentos
                                 on right.DepartamentoId equals left.DepartamentoId
                                 into temp
                                 from left in temp.DefaultIfEmpty()
                                 select new { left, right };

            var resultado = leftOuterJoin.Union(rightOuterJoin);

            var lista = (from d in resultado
                         select new ElementoConsulta
                         {
                             DepartamentoId = d.left.DepartamentoId,
                             DepartamentoNombre = d.left.Nombre,
                             EmpleadoId = d.right.EmpleadoId,
                             EmpleadoNombre = d.right.Nombre
                         }).ToList();

            return lista;
        }
    }
}
