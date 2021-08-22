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
    public class CategoriaController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public CategoriaController(VentaRepuestosContext context)
        {
            _context = context;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategoria()
        {
            var categorias = await _context.Categorias.ToListAsync();

            var categoriasDto = categorias.Select(x => {
                return new CategoriaDto()
                {
                    CategoriaId = x.CategoriaId,
                    NombreCategoria = x.NombreCategoria,
                    CategoriaPadre = x.CategoriaPadre
                };
            });

            return Ok(categoriasDto);
        }


        // GET api/<CategoriaController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriaDto>> GetCategoriaById(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDto = new CategoriaDto()
            {
                CategoriaId = categoria.CategoriaId,
                NombreCategoria = categoria.NombreCategoria,
                CategoriaPadre = categoria.CategoriaPadre
            };

            return Ok(categoriaDto);
        }



        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDto categoriaDto)
        {
            var categoria = new Categoria
            {
                CategoriaId = categoriaDto.CategoriaId,
                NombreCategoria = categoriaDto.NombreCategoria,
                CategoriaPadre = categoriaDto.CategoriaPadre
            };

            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return Created("", categoriaDto);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDto categoriaDto)
        {
            if (categoriaDto.CategoriaId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var categoria = new Categoria
            {
                CategoriaId = categoriaDto.CategoriaId,
                NombreCategoria = categoriaDto.NombreCategoria,
                CategoriaPadre = categoriaDto.CategoriaPadre
            };
            _context.Update(categoria);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
