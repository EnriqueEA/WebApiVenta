using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class DetallePedidoDto
    {

        public int detallePedidoId { get; set; }
        public int pedidoId { get; set; }
        public int productoId { get; set; }

        public int cantidad { get; set; }
        public double descuento { get; set; }
        public double subtotal { get; set; }
    }
}
