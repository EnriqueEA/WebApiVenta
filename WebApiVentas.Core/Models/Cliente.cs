using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
