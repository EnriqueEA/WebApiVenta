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
    public class LugarEntregaController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public LugarEntregaController(VentaRepuestosContext context)
        {
            _context = context;
        }

        
        // GET: api/<lugarEntregaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LugarEntregaDto>>> GetLugarEntrega()
        {
            var lugarEntregas = await _context.LugarEntregas.ToListAsync();

            var lugarEntregasDto = lugarEntregas.Select( x => new LugarEntregaDto()
                {
                    LugarEntregaId = x.LugarEntregaId,
                    DistritoId = x.DistritoId,
                    PrecioEnvio = x.PrecioEnvio
                }
            );

            return Ok(lugarEntregasDto);
        }


        // GET api/<lugarEntregaController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LugarEntregaDto>> GetLugarEntregaById(int id)
        {
            var lugarEntrega = await _context.LugarEntregas.FindAsync(id);

            if (lugarEntrega == null)
            {
                return NotFound();
            }

            var lugarEntregaDto = new LugarEntregaDto()
            {
                LugarEntregaId = lugarEntrega.LugarEntregaId,
                DistritoId = lugarEntrega.DistritoId,
                PrecioEnvio = lugarEntrega.PrecioEnvio
            };

            return Ok(lugarEntregaDto);
        }



        // POST api/<lugarEntregaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LugarEntregaDto lugarEntregaDto)
        {
            var lugarEntrega = new LugarEntrega
            {
                LugarEntregaId = lugarEntregaDto.LugarEntregaId,
                DistritoId = lugarEntregaDto.DistritoId,
                PrecioEnvio = lugarEntregaDto.PrecioEnvio
            };

            await _context.LugarEntregas.AddAsync(lugarEntrega);
            await _context.SaveChangesAsync();

            return Created("", lugarEntregaDto);
        }

        // PUT api/<lugarEntregaController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id , [FromBody] LugarEntregaDto lugarEntregaDto)
        {
            if (lugarEntregaDto.LugarEntregaId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var lugarEntrega = new LugarEntrega
            {
                LugarEntregaId = lugarEntregaDto.LugarEntregaId,
                DistritoId = lugarEntregaDto.DistritoId,
                PrecioEnvio = lugarEntregaDto.PrecioEnvio
            };
            _context.Update(lugarEntrega);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<lugarEntregaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var lugarEntrega = await _context.LugarEntregas.FindAsync(id);

            _context.LugarEntregas.Remove(lugarEntrega);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
