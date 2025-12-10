namespace SmartWarehouseDesktop.ApiModels
{
    // Modelo que representa la respuesta completa de la API al hacer login.
    // Contiene el mensaje, el token JWT y los datos del usuario autenticado.
    public class LoginResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public UserApiModel Usuario { get; set; }
    }

}
