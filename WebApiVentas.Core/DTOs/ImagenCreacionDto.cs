using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVentas.Core.Validaciones;
using WebApiVentas.Validaciones;

namespace WebApiVentas.Core.DTOs
{
    public class ImagenCreacionDto
    {


        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 4)]

        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile foto { get; set; }
        public int productoId { get; set; }

    }
}
