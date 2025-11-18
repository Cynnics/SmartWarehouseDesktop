namespace SmartWarehouseDesktop.ApiModels
{
    /// <summary>
    /// Representa un producto según lo devuelve la API.
    /// </summary>
    public class ProductApiModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
