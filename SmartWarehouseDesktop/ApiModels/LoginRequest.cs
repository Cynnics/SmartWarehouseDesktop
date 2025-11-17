namespace SmartWarehouseDesktop.ApiModels
{
    // Modelo que se envía a la API para solicitar el login.
    // Contiene exactamente los campos que exige el endpoint /api/Auth/login.
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
