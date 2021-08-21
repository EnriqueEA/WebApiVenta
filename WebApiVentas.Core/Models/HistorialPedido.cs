using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class HistorialPedido
    {
        public int HistorialPedidoId { get; set; }
        public int PedidoId { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
