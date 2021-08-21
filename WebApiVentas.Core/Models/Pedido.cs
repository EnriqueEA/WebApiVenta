using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new HashSet<DetallePedido>();
            HistorialPedidos = new HashSet<HistorialPedido>();
            Venta = new HashSet<Venta>();
        }

        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public int LugarEntregaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual LugarEntrega LugarEntrega { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
        public virtual ICollection<HistorialPedido> HistorialPedidos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
