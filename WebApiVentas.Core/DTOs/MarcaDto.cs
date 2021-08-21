using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class MarcaDto
    {
        public int marcaId { get; set; }
        public string Descripcion { get; set; }
        public int PaisId { get; set; }
    }
}
