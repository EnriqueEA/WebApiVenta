using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
   public class ProductoDto
    {

        public int productoId { get; set; }
        public int categoriaId { get; set; }
        public int marcaId { get; set; }

        public string nombreProducto { get; set; }
        public string descripcion { get; set; }
        public string modelo { get; set; }

        public int stock { get; set; }
        public double precio { get; set; }


    }
}
