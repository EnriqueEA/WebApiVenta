using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class DistritoDto
    {
        public int DistritoId { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
    }
}
