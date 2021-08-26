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
    public class ProductoController : ControllerBase
    {
        private readonly VentaRepuestosContext _context;
        public ProductoController(VentaRepuestosContext context)
        {
            _context = context;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProducto()
        {
            var producto = await _context.Productos.ToListAsync();

            var productoDto = producto.Select(producto => {
                return new ProductoDto()
                {
                    productoId = producto.ProductoId,
                    categoriaId = producto.CategoriaId,
                    marcaId = producto.MarcaId,
                    nombreProducto = producto.NombreProducto,
                    descripcion = producto.Descripcion,
                    modelo = producto.Modelo,
                    stock = producto.Stock,
                    precio = producto.Precio
                };
            });

            return Ok(productoDto);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoDto productoDto)
        {
            var producto = new Producto
            {
                ProductoId = productoDto.productoId,
                CategoriaId = productoDto.categoriaId,
                MarcaId = productoDto.marcaId,
                NombreProducto = productoDto.nombreProducto,
                Descripcion = productoDto.descripcion,
                Modelo = productoDto.modelo,
                Stock = productoDto.stock,
                Precio = productoDto.precio
            };

            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return Created("", producto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoDto productoDto)
        {
            if (productoDto.productoId != id)
            {
                return BadRequest("Los IDs no coinciden.");
            }

            var producto = new Producto
            {
                ProductoId = productoDto.productoId,
                CategoriaId = productoDto.categoriaId,
                MarcaId = productoDto.marcaId,
                NombreProducto = productoDto.nombreProducto,
                Descripcion = productoDto.descripcion,
                Modelo = productoDto.modelo,
                Stock = productoDto.stock,
                Precio = productoDto.precio
            };
            _context.Update(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}