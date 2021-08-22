using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public int? CategoriaPadre { get; set; }
    }
}
