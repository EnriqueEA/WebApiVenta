using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Marcas = new HashSet<Marca>();
        }

        public int PaisId { get; set; }
        public string Iso { get; set; }
        public string NombrePais { get; set; }

        public virtual ICollection<Marca> Marcas { get; set; }
    }
}
