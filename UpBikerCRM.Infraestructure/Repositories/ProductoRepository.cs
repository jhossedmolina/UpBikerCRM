using Microsoft.EntityFrameworkCore;
using UpBikerCRM.Core.Entities;
using UpBikerCRM.Core.Interfaces;
using UpBikerCRM.Infraestructure.Data;

namespace UpBikerCRM.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly UpBikerCrmdbContext _context;

        public ProductoRepository(UpBikerCrmdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Inventario.Producto> ListarProductosPorCategoria(string categoria)
        {
            var productList = _context.Productos.Where(x => x.Categoria == categoria).ToList();
            return productList;
        }

        public async Task<Inventario.Producto> ObtenerProductoPorParametros(string nombre, string categoria)
        {
            var product = await _context.Productos.Where(x => x.Nombre == nombre && x.Categoria == categoria).FirstOrDefaultAsync();
            return product;
        }

        public async Task AgregarProducto(Inventario.Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EliminarProducto(string nombre, string categoria)
        {
            var productoActual = await ObtenerProductoPorParametros(nombre, categoria);
            _context.Productos.Remove(productoActual);

            int registros = await _context.SaveChangesAsync();
            return registros > 0;
        }
    }
}
