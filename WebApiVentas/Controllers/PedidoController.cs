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
    public class PedidoController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public PedidoController(VentaRepuestosContext context)
        {
            _context = context;
        }

        
        // GET: api/<PedidoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetPedido()
        {
            var pedidos = await _context.Pedidos.ToListAsync();

            var pedidosDto = pedidos.Select( x => new PedidoDto()
                {
                    PedidoId = x.PedidoId,
                    ClienteId = x.ClienteId,
                    LugarEntregaId = x.LugarEntregaId,
                    FechaRegistro = x.FechaRegistro,
                    FechaEntrega = x.FechaEntrega
                }
            );

            return Ok(pedidosDto);
        }


        // GET api/<PedidoController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PedidoDto>> GetPedidoById(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            var pedidoDto = new PedidoDto()
            {
                PedidoId = pedido.PedidoId,
                ClienteId = pedido.ClienteId,
                LugarEntregaId = pedido.LugarEntregaId,
                FechaRegistro = pedido.FechaRegistro,
                FechaEntrega = pedido.FechaEntrega
            };

            return Ok(pedidoDto);
        }



        // POST api/<PedidoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PedidoDto pedidoDto)
        {
            var pedido = new Pedido
            {
                PedidoId = pedidoDto.PedidoId,
                ClienteId = pedidoDto.ClienteId,
                LugarEntregaId = pedidoDto.LugarEntregaId,
                FechaRegistro = pedidoDto.FechaRegistro,
                FechaEntrega = pedidoDto.FechaEntrega
            };

            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();

            return Created("", pedidoDto);
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id , [FromBody] PedidoDto pedidoDto)
        {
            if (pedidoDto.PedidoId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var pedido = new Pedido
            {
                PedidoId = pedidoDto.PedidoId,
                ClienteId = pedidoDto.ClienteId,
                LugarEntregaId = pedidoDto.LugarEntregaId,
                FechaRegistro = pedidoDto.FechaRegistro,
                FechaEntrega = pedidoDto.FechaEntrega
            };
            _context.Update(pedido);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
