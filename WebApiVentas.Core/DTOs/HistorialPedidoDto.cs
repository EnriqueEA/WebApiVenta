using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class HistorialPedidoDto
    {
        public int HistorialPedidoId { get; set; }
        public int PedidoId { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
