namespace SmartWarehouseDesktop.ApiModels
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public UserApiModel Usuario { get; set; }
    }

}
