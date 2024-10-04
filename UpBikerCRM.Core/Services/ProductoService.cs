using UpBikerCRM.Core.Entities;
using UpBikerCRM.Core.Interfaces;

namespace UpBikerCRM.Core.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public IEnumerable<Inventario.Producto> ListarProductosPorCategoria(string categoria)
        {
            var listaProductos = _productoRepository.ListarProductosPorCategoria(categoria);
            return listaProductos;
        }

        public async Task<Inventario.Producto> ObtenerProductoPorParametros(string nombre, string categoria)
        {
            var producto = await _productoRepository.ObtenerProductoPorParametros(nombre, categoria);
            return producto;
        }

        public async Task AgregarProducto(Inventario.Producto producto)
        {
            await _productoRepository.AgregarProducto(producto);
        }

        public async Task<bool> EliminarProducto(string nombre, string categoria)
        {
            var registros = await _productoRepository.EliminarProducto(nombre, categoria);
            return registros;
        }
    }
}
