using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class PaisDto
    {
        public int paisId { get; set; }
        public string iso { get; set; }
        public string nombrePais { get; set; }
    }
}
