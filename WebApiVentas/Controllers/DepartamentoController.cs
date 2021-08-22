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
    public class DepartamentoController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public DepartamentoController(VentaRepuestosContext context)
        {
            _context = context;
        }

        // GET: api/<DepartamentoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetDepartamento()
        {
            var departamentos = await _context.Departamentos.ToListAsync();

            var departamentosDto = departamentos.Select(x => {
                return new DepartamentoDto()
                {
                    DepartamentoId = x.DepartamentoId,
                    Nombre = x.Nombre
                };
            });

            return Ok(departamentosDto);
        }


        // GET api/<DepartamentoController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartamentoDto>> GetDepartamentoById(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            var departamentoDto = new DepartamentoDto()
            {
                DepartamentoId = departamento.DepartamentoId,
                Nombre = departamento.Nombre
            };

            return Ok(departamentoDto);
        }



        // POST api/<DepartamentoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DepartamentoDto departamentoDto)
        {
            var departamento = new Departamento
            {
                DepartamentoId = departamentoDto.DepartamentoId,
                Nombre = departamentoDto.Nombre
            };

            await _context.Departamentos.AddAsync(departamento);
            await _context.SaveChangesAsync();

            return Created("", departamentoDto);
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DepartamentoDto departamentoDto)
        {
            if (departamentoDto.DepartamentoId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var departamento = new Departamento
            {
                DepartamentoId = departamentoDto.DepartamentoId,
                Nombre = departamentoDto.Nombre
            };
            _context.Update(departamento);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
