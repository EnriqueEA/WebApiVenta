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
    public class UsuarioController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public UsuarioController(VentaRepuestosContext context)
        {
            _context = context;
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuario()
        {
            var usuario = await _context.Usuarios.ToListAsync();

            var usuarioDto = usuario.Select(usuario => {
                return new UsuarioDto()
                {
                    usuarioId = usuario.UsuarioId,
                    nombre = usuario.NombreUsuario,
                    contraseña = usuario.Contrasena,
                    fechaCreacion = usuario.FechaCreacion,
                    rolId = usuario.RolId
                };
            });

            return Ok(usuarioDto);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                UsuarioId = usuarioDto.usuarioId,
                NombreUsuario = usuarioDto.nombre,
                Contrasena = usuarioDto.contraseña,
                FechaCreacion = usuarioDto.fechaCreacion,
                RolId = usuarioDto.rolId
            };

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return Created("", usuarioDto);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto.usuarioId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var usuario = new Usuario
            {
                UsuarioId = usuarioDto.usuarioId,
                NombreUsuario = usuarioDto.nombre,
                Contrasena = usuarioDto.contraseña,
                FechaCreacion = usuarioDto.fechaCreacion,
                RolId = usuarioDto.rolId
            };
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
