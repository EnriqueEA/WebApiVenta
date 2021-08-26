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
    public class PaisController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public PaisController(VentaRepuestosContext context)
        {
            _context = context;
        }


        // GET: api/<PaisController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisDto>>> GetPais()
        {
            var pais = await _context.Pais.ToListAsync();

            var paisDto = pais.Select(pais => {
                return new PaisDto()
                {
                    paisId = pais.PaisId,
                    iso = pais.Iso,
                    nombrePais = pais.NombrePais
                };
            });

            return Ok(paisDto);
        }

        // POST api/<PaisController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PaisDto paisDto)
        {
            var pais = new Pais
            {
                PaisId = paisDto.paisId,
                Iso = paisDto.iso,
                NombrePais = paisDto.nombrePais
            };

            await _context.Pais.AddAsync(pais);
            await _context.SaveChangesAsync();

            return Created("", paisDto);
        }

        // PUT api/<PaisController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PaisDto paisDto)
        {
            if (paisDto.paisId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var pais = new Pais
            {
                PaisId = paisDto.paisId,
                Iso = paisDto.iso,
                NombrePais = paisDto.nombrePais
            };

            _context.Update(pais);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<PaisController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pais = await _context.Pais.FindAsync(id);

            _context.Pais.Remove(pais);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
