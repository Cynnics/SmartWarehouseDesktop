namespace SmartWarehouseDesktop.ApiModels
{
    // Clase estática que almacena los datos de la sesión activa
    // después de un login exitoso. Permite acceder al token y al usuario
    // desde cualquier parte de la aplicación.
    public static class Session
    {
        public static string Token { get; set; }
        public static UsuarioModel UsuarioActual { get; set; }
        public static void Clear()
        {
            Token = null;
            UsuarioActual = null;
        }

    }

}
