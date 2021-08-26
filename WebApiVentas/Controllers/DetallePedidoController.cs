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
    public class DetallePedidoController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public DetallePedidoController(VentaRepuestosContext context)
        {
            _context = context;
        }


        // GET: api/<DetallePedidoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedidoDto>>> GetDetallePedido()
        {
            var detallepedido = await _context.DetallePedidos.ToListAsync();

            var detallePedidoDto = detallepedido.Select(detallepedido => {
                return new DetallePedidoDto()
                {
                    detallePedidoId = detallepedido.DetallePedidoId,
                    pedidoId = detallepedido.PedidoId,
                    productoId = detallepedido.ProductoId,
                    descuento = detallepedido.Descuento,
                    cantidad = detallepedido.Cantidad,
                    subtotal = detallepedido.Subtotal
                };
            });

            return Ok(detallePedidoDto);
        }

        // POST api/<DetallePedidoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetallePedidoDto detallePedidoDto)
        {
            var detallepedido = new DetallePedido
            {
                DetallePedidoId  = detallePedidoDto.detallePedidoId,
                PedidoId = detallePedidoDto.pedidoId,
                ProductoId = detallePedidoDto.productoId,
                Descuento = detallePedidoDto.descuento,
                Cantidad = detallePedidoDto.cantidad,
                Subtotal = detallePedidoDto.subtotal
            };

            await _context.DetallePedidos.AddAsync(detallepedido);
            await _context.SaveChangesAsync();

            return Created("", detallepedido);
        }

        // PUT api/<DetallePedidoController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetallePedidoDto detallePedidoDto)
        {
            if (detallePedidoDto.detallePedidoId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var detallepedido = new DetallePedido
            {
                DetallePedidoId = detallePedidoDto.detallePedidoId,
                PedidoId = detallePedidoDto.pedidoId,
                ProductoId = detallePedidoDto.productoId,
                Descuento = detallePedidoDto.descuento,
                Cantidad = detallePedidoDto.cantidad,
                Subtotal = detallePedidoDto.subtotal
            };
            _context.Update(detallepedido);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<DetallePedidoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var detallepedido = await _context.DetallePedidos.FindAsync(id);

            _context.DetallePedidos.Remove(detallepedido);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}