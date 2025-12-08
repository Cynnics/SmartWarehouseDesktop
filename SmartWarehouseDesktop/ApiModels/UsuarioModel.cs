namespace SmartWarehouseDesktop.ApiModels
{

    // Representa la información del usuario devuelta por la API.
    // Es equivalente al objeto "usuario" dentro del JSON de LoginResponse.
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        
    }

}
