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
        // ❗ La API devuelve también Password, pero jamás
        // debemos manejar contraseñas en escritorio.
        // Si algún día haces "cambiar contraseña", será otro endpoint.
    }
}
