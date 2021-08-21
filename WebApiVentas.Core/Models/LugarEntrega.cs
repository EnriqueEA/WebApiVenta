using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class LugarEntrega
    {
        public LugarEntrega()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int LugarEntregaId { get; set; }
        public int DistritoId { get; set; }
        public decimal PrecioEnvio { get; set; }

        public virtual Distrito Distrito { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
