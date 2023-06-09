﻿using Consultas.Entidades;
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

        public List<ElementoConsulta> ConsultaDepartamentos_ConsultaExclusiva()
        {
            var query = $"SELECT {camposSelect} FROM Departamento A LEFT JOIN Empleado B ON A.DepartamentoId = B.DepartamentoId WHERE B.DepartamentoId IS NULL";
            return ConsultaGenerica(query);
        }

        public List<ElementoConsulta> ConsultaTotal()
        {
            var query = $"SELECT {camposSelect} FROM Departamento A FULL OUTER JOIN Empleado B ON A.DepartamentoId = B.DepartamentoId";
            return ConsultaGenerica(query);
        }

        public List<ElementoConsulta> ConsultaDepartamentosConEmpleados()
        {
            var query = $"SELECT {camposSelect} FROM Departamento A INNER JOIN Empleado B ON A.DepartamentoId = B.DepartamentoId";
            return ConsultaGenerica(query);
        }

        public List<ElementoConsulta> ConsultaDepartamentosEmpleadosDesconectados()
        {
            var query = $"SELECT {camposSelect} FROM Departamento A FULL OUTER JOIN Empleado B ON A.DepartamentoId = B.DepartamentoId WHERE A.DepartamentoId IS NULL OR B.DepartamentoId IS NULL";
            return ConsultaGenerica(query);
        }

        public List<ElementoConsulta> ConsultaEmpleados_ConsultaInclusiva()
        {
            var query = $"SELECT {camposSelect} FROM dbo.Departamento A RIGHT JOIN dbo.Empleado B ON A.DepartamentoId = B.DepartamentoId";
            return ConsultaGenerica(query);
        }

        public List<ElementoConsulta> ConsultaEmpleados_ConsultaExclusiva()
        {
            var query = $"SELECT {camposSelect} FROM Departamento A RIGHT JOIN Empleado B ON A.DepartamentoId = B.DepartamentoId WHERE A.DepartamentoId IS NULL";
            return ConsultaGenerica(query);
        }
    }
}
