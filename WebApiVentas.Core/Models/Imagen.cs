using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Imagen
    {
        public int ImagenId { get; set; }
        public string Url { get; set; }
        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
