using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            LugarEntregas = new HashSet<LugarEntrega>();
        }

        public int DistritoId { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }

        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<LugarEntrega> LugarEntregas { get; set; }
    }
}
