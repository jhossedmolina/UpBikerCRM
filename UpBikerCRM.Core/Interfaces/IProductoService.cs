using UpBikerCRM.Core.Entities;

namespace UpBikerCRM.Core.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Inventario.Producto> ListarProductosPorCategoria(string categoria);

        Task<Inventario.Producto> ObtenerProductoPorParametros(string nombre, string categoria);

        Task AgregarProducto(Inventario.Producto producto);

        Task<bool> EliminarProducto(string nombre, string categoria);
    }
}
