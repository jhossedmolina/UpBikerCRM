using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using UpBikerCRM.Core.DTOs;
using UpBikerCRM.Core.Entities;
using UpBikerCRM.Core.Interfaces;

namespace UpBikerCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductoService _productoService;

        public ProductoController(IMapper mapper, IProductoService productoService)
        {
            _mapper = mapper;
            _productoService = productoService;
        }

        [HttpGet("{categoria}")]
        public async Task<IActionResult> ListarProductosPorCategoria(string categoria)
        {
            var productos = _productoService.ListarProductosPorCategoria(categoria);

            if (!productos.Any())
            {
                return NotFound();
            }

            var productsDto = _mapper.Map<IEnumerable<ProductoDto>>(productos);
            return Ok(productsDto);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProducto(ProductoDto productDto)
        {
            var product = _mapper.Map<Inventario.Producto>(productDto);
            await _productoService.AgregarProducto(product);

            productDto = _mapper.Map<ProductoDto>(product);
            return Ok(productDto);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarProducto(string nombre, string categoria)
        {
            var producto = await _productoService.ObtenerProductoPorParametros(nombre, categoria);
            if(producto is null)
            {
                return NotFound();
            }

            var resultado = await _productoService.EliminarProducto(nombre, categoria);
            return NoContent();
        }
    }
}
