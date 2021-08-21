using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Core.DTOs;
using WebApiVentas.Core.Models;
using WebApiVentas.Infrastructure.Data;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public MarcaController(VentaRepuestosContext context)
        {
            _context = context;
        }

        
        // GET: api/<MarcaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> GetMarca()
        {
            var marcas = await _context.Marcas.ToListAsync();

            var marcasDto = marcas.Select( marca => {
                return new MarcaDto()
                {
                    marcaId = marca.MarcaId,
                    Descripcion = marca.Descripcion,
                    PaisId = marca.PaisId
                };
            });

            return Ok(marcasDto);
        }


        // GET api/<MarcaController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MarcaDto>> GetMarcaById(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            var marcaDto = new MarcaDto()
            {
                marcaId = marca.MarcaId,
                Descripcion = marca.Descripcion,
                PaisId = marca.PaisId
            };

            return Ok(marcaDto);
        }



        // POST api/<MarcaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MarcaDto marcaDto)
        {
            var marca = new Marca
            {
                Descripcion = marcaDto.Descripcion,
                PaisId = marcaDto.PaisId
            };

            await _context.Marcas.AddAsync(marca);
            await _context.SaveChangesAsync();

            return Created("", marcaDto);
        }

        // PUT api/<MarcaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MarcaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
