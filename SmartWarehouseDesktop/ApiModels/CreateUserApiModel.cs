namespace SmartWarehouseDesktop.ApiModels
{
    public class CreateUserApiModel
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // solo para creación
        public string Rol { get; set; }
    }
}
