namespace SmartWarehouseDesktop.ApiModels
{
    
    public static class Session
    {
        public static string Token { get; set; }
        public static UserApiModel UsuarioActual { get; set; }
        public static void Clear()
        {
            Token = null;
            UsuarioActual = null;
        }

    }

}
