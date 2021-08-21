using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Distritos = new HashSet<Distrito>();
        }

        public int ProvinciaId { get; set; }
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; }
    }
}
