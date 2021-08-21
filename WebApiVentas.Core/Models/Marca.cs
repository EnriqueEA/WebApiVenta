using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public int MarcaId { get; set; }
        public int PaisId { get; set; }
        public string Descripcion { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
