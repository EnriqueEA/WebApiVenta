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
    public class DistritoController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public DistritoController(VentaRepuestosContext context)
        {
            _context = context;
        }

        // GET: api/<DistritoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistritoDto>>> GetDistrito()
        {
            var distritos = await _context.Distritos.ToListAsync();

            var distritosDto = distritos.Select(x => {
                return new DistritoDto()
                {
                    DistritoId = x.DistritoId,
                    ProvinciaId = x.ProvinciaId,
                    Nombre = x.Nombre
                };
            });

            return Ok(distritosDto);
        }


        // GET api/<DistritoController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DistritoDto>> GetDistritoById(int id)
        {
            var distrito = await _context.Distritos.FindAsync(id);

            if (distrito == null)
            {
                return NotFound();
            }

            var distritoDto = new DistritoDto()
            {
                DistritoId = distrito.DistritoId,
                ProvinciaId = distrito.ProvinciaId,
                Nombre = distrito.Nombre
            };

            return Ok(distritoDto);
        }



        // POST api/<DistritoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DistritoDto distritoDto)
        {
            var distrito = new Distrito
            {
                DistritoId = distritoDto.DistritoId,
                ProvinciaId = distritoDto.ProvinciaId,
                Nombre = distritoDto.Nombre
            };

            await _context.Distritos.AddAsync(distrito);
            await _context.SaveChangesAsync();

            return Created("", distritoDto);
        }

        // PUT api/<DistritoController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DistritoDto distritoDto)
        {
            if (distritoDto.DistritoId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var distrito = new Distrito
            {
                DistritoId = distritoDto.DistritoId,
                ProvinciaId = distritoDto.ProvinciaId,
                Nombre = distritoDto.Nombre
            };
            _context.Update(distrito);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<DistritoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var distrito = await _context.Distritos.FindAsync(id);

            _context.Distritos.Remove(distrito);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
