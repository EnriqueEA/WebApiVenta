using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class DetallePedido
    {
        public int DetallePedidoId { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public decimal Descuento { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
