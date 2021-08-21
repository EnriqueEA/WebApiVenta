using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Provincia = new HashSet<Provincia>();
        }

        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}
