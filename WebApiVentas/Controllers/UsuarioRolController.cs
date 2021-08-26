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
    public class UsuarioRolController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public UsuarioRolController(VentaRepuestosContext context)
        {
            _context = context;
        }


        // GET: api/<UsuarioRolController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRolDto>>> GetUsuarioRol()
        {
            var usuariorol = await _context.UsuarioRols.ToListAsync();

            var usuarioRolDto = usuariorol.Select(usuariorol => {
                return new UsuarioRolDto()
                {
                    usuarioRolId = usuariorol.UsuarioRolId,
                    usuarioId = usuariorol.UsuarioId,
                    rolId = usuariorol.RolId
                };
            });

            return Ok(usuarioRolDto);
        }

        // POST api/<UsuarioRolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioRolDto usuarioRolDto)
        {
            var usuariorol = new UsuarioRol
            {
                UsuarioRolId = usuarioRolDto.usuarioRolId,
                UsuarioId = usuarioRolDto.usuarioId,
                RolId = usuarioRolDto.rolId
            };

            await _context.UsuarioRols.AddAsync(usuariorol);
            await _context.SaveChangesAsync();

            return Created("", usuarioRolDto);
        }

        // PUT api/<UsuarioRolController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioRolDto usuarioRolDto)
        {
            if (usuarioRolDto.usuarioRolId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var usuariorol = new UsuarioRol
            {
                UsuarioRolId = usuarioRolDto.usuarioRolId,
                UsuarioId = usuarioRolDto.usuarioId,
                RolId = usuarioRolDto.rolId
            };
            _context.Update(usuariorol);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<UsuarioRolController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuariorol = await _context.UsuarioRols.FindAsync(id);

            _context.UsuarioRols.Remove(usuariorol);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}

