using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class ProvinciaDto
    {
        public int ProvinciaId { get; set; }
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
    }
}
