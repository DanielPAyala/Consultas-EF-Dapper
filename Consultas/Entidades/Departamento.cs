using System;
using System.Collections.Generic;

namespace Consultas.Entidades
{
    public partial class Departamento
    {
        public Departamento()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int DepartamentoId { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
