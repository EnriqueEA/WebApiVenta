using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Core.DTOs;
using WebApiVentas.Core.Models;
using WebApiVentas.Infrastructure.Data;
using WebApiVentas.Servicios;

namespace WebApiVentas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesController: ControllerBase
    {

        private readonly VentaRepuestosContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;

        public ImagenesController(VentaRepuestosContext context, IMapper mapper, IAlmacenadorArchivos _almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            almacenadorArchivos = _almacenadorArchivos;
        }



        // POST api/<ImagenesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ImagenCreacionDto imagenCreacionDto)
        {
            var entidad = mapper.Map<Imagen>(imagenCreacionDto);

            if (imagenCreacionDto.foto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagenCreacionDto.foto.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(imagenCreacionDto.foto.FileName);
                    entidad.Url = await almacenadorArchivos.GuardarArchivo(contenido, extension, "productos", imagenCreacionDto.foto.ContentType);

                }

            }
            context.Add(entidad);
            await context.SaveChangesAsync();
            var dto = mapper.Map<ImagenDto>(entidad);
            return Ok();
        }

    }
}
