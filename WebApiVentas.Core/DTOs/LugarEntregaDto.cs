using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class LugarEntregaDto
    {
        public int LugarEntregaId { get; set; }
        public int DistritoId { get; set; }
        public double PrecioEnvio { get; set; }
    }
}
