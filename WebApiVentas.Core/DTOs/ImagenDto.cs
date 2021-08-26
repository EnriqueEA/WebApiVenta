using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class ImagenDto
    {

        public int imagenId { get; set; }
        public string  url { get; set; }
        public int productoId { get; set; }
    }
}
