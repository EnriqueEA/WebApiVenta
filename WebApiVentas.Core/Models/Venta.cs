using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Venta
    {
        public int VentaId { get; set; }
        public int PedidoId { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
