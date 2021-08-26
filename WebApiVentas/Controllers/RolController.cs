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
    public class RolController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public RolController(VentaRepuestosContext context)
        {
            _context = context;
        }


        // GET: api/<RolController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolDto>>> GetRol()
        {
            var rol = await _context.Rols.ToListAsync();

            var rolDto = rol.Select(rol => {
                return new RolDto()
                {
                    rolId = rol.RolId,
                    nombreRol = rol.NombreRol
                };
            });

            return Ok(rolDto);
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolDto rolDto)
        {
            var rol = new Rol
            {
                RolId = rolDto.rolId,
                NombreRol = rolDto.nombreRol
            };

            await _context.Rols.AddAsync(rol);
            await _context.SaveChangesAsync();

            return Created("", rolDto);
        }

        // PUT api/<RolController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] RolDto rolDto)
        {
            if (rolDto.rolId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var rol = new Rol
            {
                RolId = rolDto.rolId,
                NombreRol = rolDto.nombreRol
            };
            _context.Update(rol);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rol = await _context.Rols.FindAsync(id);

            _context.Rols.Remove(rol);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
