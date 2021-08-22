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
    public class ProvinciaController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public ProvinciaController(VentaRepuestosContext context)
        {
            _context = context;
        }

        // GET: api/<ProvinciaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProvinciaDto>>> GetProvincia()
        {
            var provincias = await _context.Provincias.ToListAsync();

            var provinciasDto = provincias.Select(x => {
                return new ProvinciaDto()
                {
                    ProvinciaId = x.ProvinciaId,
                    DepartamentoId = x.DepartamentoId,
                    Nombre = x.Nombre
                };
            });

            return Ok(provinciasDto);
        }


        // GET api/<ProvinciaController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProvinciaDto>> GetProvinciaById(int id)
        {
            var provincia = await _context.Provincias.FindAsync(id);

            if (provincia == null)
            {
                return NotFound();
            }

            var provinciaDto = new ProvinciaDto()
            {
                ProvinciaId = provincia.ProvinciaId,
                DepartamentoId = provincia.DepartamentoId,
                Nombre = provincia.Nombre
            };

            return Ok(provinciaDto);
        }



        // POST api/<ProvinciaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProvinciaDto provinciaDto)
        {
            var provincia = new Provincia
            {
                ProvinciaId = provinciaDto.ProvinciaId,
                DepartamentoId = provinciaDto.DepartamentoId,
                Nombre = provinciaDto.Nombre
            };

            await _context.Provincias.AddAsync(provincia);
            await _context.SaveChangesAsync();

            return Created("", provinciaDto);
        }

        // PUT api/<ProvinciaController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProvinciaDto provinciaDto)
        {
            if (provinciaDto.ProvinciaId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var provincia = new Provincia
            {
                ProvinciaId = provinciaDto.ProvinciaId,
                DepartamentoId = provinciaDto.DepartamentoId,
                Nombre = provinciaDto.Nombre
            };
            _context.Update(provincia);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<ProvinciaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var provincia = await _context.Provincias.FindAsync(id);

            _context.Provincias.Remove(provincia);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
