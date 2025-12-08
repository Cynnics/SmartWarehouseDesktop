namespace SmartWarehouseDesktop.ApiModels
{
    /// <summary>
    /// Representa un usuario tal como lo devuelve la API.
    /// </summary>
    public class UserApiModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Telefono { get; set; }
        public string DireccionFacturacion { get; set; }
        public string Nif { get; set; }
    }
}
