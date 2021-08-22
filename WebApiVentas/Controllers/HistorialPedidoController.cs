using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Core.DTOs;
using WebApiVentas.Core.Models;
using WebApiVentas.Infrastructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialPedidoController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public HistorialPedidoController(VentaRepuestosContext context)
        {
            _context = context;
        }

        // GET: api/<HistorialPedidoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialPedidoDto>>> GetHistorialPedido()
        {
            var historialPedidos = await _context.HistorialPedidos.ToListAsync();

            var historialPedidosDto = historialPedidos.Select(x => {
                return new HistorialPedidoDto()
                {
                    HistorialPedidoId = x.HistorialPedidoId,
                    PedidoId = x.PedidoId,
                    Estado = x.Estado,
                    Fecha = x.Fecha
                };
            });

            return Ok(historialPedidosDto);
        }


        // GET api/<HistorialPedidoController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HistorialPedidoDto>> GetHistorialPedidoById(int id)
        {
            var historialPedido = await _context.HistorialPedidos.FindAsync(id);

            if (historialPedido == null)
            {
                return NotFound();
            }

            var historialPedidoDto = new HistorialPedidoDto()
            {
                HistorialPedidoId = historialPedido.HistorialPedidoId,
                PedidoId = historialPedido.PedidoId,
                Estado = historialPedido.Estado,
                Fecha = historialPedido.Fecha
            };

            return Ok(historialPedidoDto);
        }



        // POST api/<HistorialPedidoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HistorialPedidoDto historialPedidoDto)
        {
            var historialPedido = new HistorialPedido
            {
                HistorialPedidoId = historialPedidoDto.HistorialPedidoId,
                PedidoId = historialPedidoDto.PedidoId,
                Estado = historialPedidoDto.Estado,
                Fecha = historialPedidoDto.Fecha
            };

            await _context.HistorialPedidos.AddAsync(historialPedido);
            await _context.SaveChangesAsync();

            return Created("", historialPedidoDto);
        }

        // PUT api/<HistorialPedidoController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] HistorialPedidoDto historialPedidoDto)
        {
            if (historialPedidoDto.HistorialPedidoId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var historialPedido = new HistorialPedido
            {
                HistorialPedidoId = historialPedidoDto.HistorialPedidoId,
                PedidoId = historialPedidoDto.PedidoId,
                Estado = historialPedidoDto.Estado,
                Fecha = historialPedidoDto.Fecha
            };
            _context.Update(historialPedido);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<HistorialPedidoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var historialPedido = await _context.HistorialPedidos.FindAsync(id);

            _context.HistorialPedidos.Remove(historialPedido);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
