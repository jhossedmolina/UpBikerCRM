namespace UpBikerCRM.Core.Entities
{
    public class Inventario
    {
        public class Producto
        {
            public int Id { get; set; }

            public string Nombre { get; set; } = null!;

            public decimal Precio { get; set; }

            public string Categoria { get; set; } = null!;
        }
    }
}
