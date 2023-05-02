using System;
using System.Collections.Generic;

namespace Consultas.Entidades
{
    public partial class Empleado
    {
        public int EmpleadoId { get; set; }
        public int? DepartamentoId { get; set; }
        public string? Nombre { get; set; }

        public virtual Departamento? Departamento { get; set; }
    }
}
