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
    public class ClienteController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public ClienteController(VentaRepuestosContext context)
        {
            _context = context;
        }

        // GET: api/<clienteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetCliente()
        {
            var clientes = await _context.Clientes.ToListAsync();

            var clientesDto = clientes.Select(cliente => {
                return new ClienteDto()
                {
                    ClienteId = cliente.ClienteId,
                    Nombres = cliente.Nombres,
                    Apellidos = cliente.Apellidos,
                    Direccion = cliente.Direccion,
                    Celular = cliente.Celular
                };
            });

            return Ok(clientesDto);
        }


        // GET api/<clienteController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteDto>> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDto = new ClienteDto()
            {
                ClienteId = cliente.ClienteId,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                Direccion = cliente.Direccion,
                Celular = cliente.Celular
            };

            return Ok(clienteDto);
        }



        // POST api/<clienteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                ClienteId = clienteDto.ClienteId,
                Nombres = clienteDto.Nombres,
                Apellidos = clienteDto.Apellidos,
                Direccion = clienteDto.Direccion,
                Celular = clienteDto.Celular
            };

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return Created("", clienteDto);
        }

        // PUT api/<clienteController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDto clienteDto)
        {
            if (clienteDto.ClienteId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var cliente = new Cliente
            {
                ClienteId = clienteDto.ClienteId,
                Nombres = clienteDto.Nombres,
                Apellidos = clienteDto.Apellidos,
                Direccion = clienteDto.Direccion,
                Celular = clienteDto.Celular
            };
            _context.Update(cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<clienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
